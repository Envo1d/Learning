using MessageLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Socket Socket { get; set; }
        bool isClicked = false;
        CancellationToken token;
        CancellationTokenSource source;
        Task Listening { get; set; }

        public ObservableCollection<string> Users { get; set; }
         public MainWindow()
        {
            InitializeComponent();
            Users = new();
           DataContext = this;
        }

        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var end = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10_000);
                await Socket.ConnectAsync(end);
                btnConnect.Content = "Disconnect";
                btnSend.IsEnabled = true;

                using (NetworkStream str = new NetworkStream(Socket))
                using (StreamWriter wr = new StreamWriter(str))
                {
                    await wr.WriteLineAsync($"{(int)MessageType.SetNickname}");
                    Thread.Sleep(10);
                    await wr.WriteLineAsync(txtName.Text);
                }
                txtName.IsEnabled = false;
                Listening = Task.Run(async () =>
                {
                    string msg;
                    while (!token.IsCancellationRequested)
                    {
                        using (NetworkStream str = new NetworkStream(Socket))
                        using (StreamReader rd = new StreamReader(str))
                        {
                            msg = await rd.ReadLineAsync();
                            if (int.Parse(msg) == (int)MessageType.SendingList)
                            {
                                string tmp = "";
                                {
                                    while (true)
                                    {
                                        try
                                        {
                                            tmp = await rd.ReadLineAsync();
                                        }
                                        catch (Exception ex) { Debug.WriteLine(ex); }
                                        if (tmp != "")
                                            try
                                            {
                                                Dispatcher.Invoke(() => Users.Add(tmp));
                                            }
                                            catch (Exception ex) { Debug.WriteLine("client add error"); }
                                        else break;
                                    }
                                }
                            }
                            if(int.Parse(msg) == (int)MessageType.SetDefaultName)
                            {
                                string tmp = "";
                                try
                                {
                                    tmp = await rd.ReadLineAsync();
                                }
                                catch (Exception ex) { Debug.WriteLine(ex); }
                                Dispatcher.Invoke(() => txtName.Text=tmp);
                            }
                            if (int.Parse(msg) == (int)MessageType.SendingMessage)
                            {
                                string tmp = "";
                                try
                                {
                                    tmp = await rd.ReadLineAsync();
                                }
                                catch (Exception ex) { Debug.WriteLine(ex); }
                                Dispatcher.Invoke(() => msgList.Items.Add(tmp));
                            }
                            if (int.Parse(msg) == (int)MessageType.ConnectedNewUser)
                            {
                                string tmp = "";
                                try
                                {
                                    tmp = await rd.ReadLineAsync();
                                }
                                catch (Exception ex) { Debug.WriteLine(ex); }
                                Dispatcher.Invoke(() => Users.Add(tmp));
                            }
                            if (int.Parse(msg) == (int)MessageType.UserDisconnected)
                            {
                                string tmp = "";
                                try
                                {
                                    tmp = await rd.ReadLineAsync();
                                }
                                catch (Exception ex) { Debug.WriteLine(ex); }
                                Dispatcher.Invoke(() => Users.Remove(tmp));
                            }
                        }
                    }
                }, token);
                btnConnect.IsEnabled = false;
                btnConnect.Visibility = Visibility.Hidden;
            }
            else
            {
                txtName.Background = Brushes.Red;
            }
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (usersList.SelectedIndex == -1)
            {
                using (NetworkStream str = new NetworkStream(Socket))
                using (StreamWriter wr = new StreamWriter(str))
                {
                    await wr.WriteLineAsync($"{(int)MessageType.SendingMessage}");
                    Thread.Sleep(10);
                    await wr.WriteLineAsync(txtMsg.Text);
                    msgList.Items.Add($"To All Users: {txtMsg.Text}");
                }
            }
            else
            {
                using (NetworkStream str = new NetworkStream(Socket))
                using (StreamWriter wr = new StreamWriter(str))
                {
                    await wr.WriteLineAsync($"{(int)MessageType.SendMessageToUser}");
                    Thread.Sleep(10);
                    await wr.WriteLineAsync(usersList.SelectedItem.ToString());
                    Thread.Sleep(10);
                    await wr.WriteLineAsync($"{(int)MessageType.SendingMessage}");
                    Thread.Sleep(10);
                    await wr.WriteLineAsync(txtMsg.Text);
                    msgList.Items.Add($"To {usersList.SelectedItem.ToString()}: {txtMsg.Text}");
                }
            }
            txtMsg.Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            btnSend.IsEnabled = false;
            source = new();
            token = source.Token;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Socket != null)
                Socket.Close();
            source.Cancel();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtName.Background = Brushes.White;
        }
    }
}
