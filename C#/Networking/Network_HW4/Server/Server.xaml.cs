using MessageLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Socket Socket { get; set; }
        CancellationToken token;
        CancellationTokenSource source;

        ConcurrentDictionary<string, Socket> Clients { get; set; }
        int DefaultNicnamesCount { get; set; } = 0;

        bool isClicked = false;
        Task ListenClient { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (!isClicked)
            {
                infoList.Items.Add("Server started");
                ListenClient = Task.Run(async () =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        try
                        {
                            var client = await Socket.AcceptAsync();
                            await Task.Run(() => HandleClient(client), token);
                        }
                        catch (Exception ex) { Debug.WriteLine(ex); }
                        
                    }
                }, token);
                btnStart.Content = "Stop";
                isClicked = !isClicked;
            }
            else
            {
                infoList.Items.Add("Server aborted");
                btnStart.Content = "Start";
                source.Cancel();
                isClicked = !isClicked;
            }
        }

        private async void HandleClient(Socket client)
        {
            infoList.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            { infoList.Items.Add($"{client.RemoteEndPoint} connected"); }));

            if (Clients.Count > 0)
            {
                using (NetworkStream str = new NetworkStream(client))
                using (StreamWriter wr = new StreamWriter(str))
                {
                    wr.AutoFlush = true;
                    await wr.WriteLineAsync($"{(int)MessageType.SendingList}");
                    await Task.Delay(10);
                    foreach (var item in Clients.Keys)
                    {
                        await wr.WriteLineAsync(item);
                    }
                    await wr.WriteLineAsync("");
                }
            }

            string msg;
            while (!token.IsCancellationRequested)
            {
                using (NetworkStream str = new NetworkStream(client))
                using (StreamReader rd = new StreamReader(str))
                    try {
                        msg = await rd.ReadLineAsync();
                        if(int.Parse(msg) == (int)MessageType.SetNickname)
                        {
                            msg = await rd.ReadLineAsync();
                            if (!Clients.ContainsKey(msg))
                                Clients.TryAdd(msg, client);
                            else
                            {
                                msg = $"Username{DefaultNicnamesCount++}";
                                Clients.TryAdd(msg, client);
                                using (NetworkStream strU = new NetworkStream(client))
                                using (StreamWriter wr = new StreamWriter(strU))
                                {
                                    await wr.WriteLineAsync($"{(int)MessageType.SetDefaultName}");
                                    await Task.Delay(10);
                                    await wr.WriteLineAsync(msg);
                                }
                            }
                            infoList.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                            { infoList.Items.Add($"{client.RemoteEndPoint} now has name: {msg}"); }));

                            foreach (var item in Clients.Values)
                            {
                                if(item != client)
                                using (NetworkStream strU = new NetworkStream(item))
                                using (StreamWriter wr = new StreamWriter(strU))
                                {
                                    await wr.WriteLineAsync($"{(int)MessageType.ConnectedNewUser}");
                                    await Task.Delay(10);
                                    await wr.WriteLineAsync(msg);
                                }
                            }
                            continue;
                        }
                        if(int.Parse(msg) == (int)MessageType.SendMessageToUser)
                        {
                            string receiver = await rd.ReadLineAsync();
                            msg = await rd.ReadLineAsync();
                            if(int.Parse(msg) == (int)MessageType.SendingMessage)
                            {
                                string message = await rd.ReadLineAsync();
                                using (NetworkStream strU = new NetworkStream(Clients[receiver]))
                                using (StreamWriter wr = new StreamWriter(strU))
                                {
                                    await wr.WriteLineAsync($"{(int)MessageType.SendingMessage}");
                                    await Task.Delay(10);
                                    await wr.WriteLineAsync(Clients.FirstOrDefault(x => x.Value == client).Key + ": " + message);
                                }
                            }
                            continue;
                        }
                        if (int.Parse(msg) == (int)MessageType.SendingMessage)
                        {
                            string message = await rd.ReadLineAsync();
                            string sender = Clients.FirstOrDefault(x => x.Value == client).Key;
                            foreach (var item in Clients.Values)
                            {
                                if(item != client)
                                using (NetworkStream strU = new NetworkStream(item))
                                using (StreamWriter wr = new StreamWriter(strU))
                                {
                                    await wr.WriteLineAsync($"{(int)MessageType.SendingMessage}");
                                    await Task.Delay(10);
                                    await wr.WriteLineAsync(sender + ": " + message);
                                }
                            }
                            continue;
                        }
                    }
                    catch {
                        infoList.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                        { infoList.Items.Add($"{client.RemoteEndPoint} disconnected"); }));
                        string nick = Clients.FirstOrDefault(x => x.Value == client).Key;
                        foreach (var item in Clients.Values)
                        {
                            if (item != client)
                                using (NetworkStream strU = new NetworkStream(item))
                                using (StreamWriter wr = new StreamWriter(strU))
                                {
                                    await wr.WriteLineAsync($"{(int)MessageType.UserDisconnected}");
                                    await Task.Delay(10);
                                    await wr.WriteLineAsync(nick);
                                }
                        }
                        Socket tmp;
                        Clients.Remove(nick, out tmp);
                        break; }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            source = new();
            token = source.Token;
            var end = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10_000);
            Socket.Bind(end);
            Socket.Listen();
            Clients = new();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            source.Cancel();
            if (Socket != null)
                Socket.Close();
        }
    }
}
