using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections.Concurrent;

namespace Server
{
    public partial class Server : Form
    {
        Socket Socket { get; set; }
        CancellationToken token;
        CancellationTokenSource source;
        ConcurrentBag<Socket> Clients { get; set; } = new();
        bool isClicked = false;
        Task ListenClient { get; set; }
        public Server()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isClicked)
            {
                var end = new IPEndPoint(IPAddress.Parse("127.0.0.1"), (int)numericUpDown1.Value);
                Socket.Bind(end);
                Socket.Listen();
                ListenClient = Task.Run(async () =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        var client = await Socket.AcceptAsync();
                        Clients.Add(client);
                        await Task.Run(() => HandleClient(client), token);
                    }
                }, token);
                btnSend.Enabled = true;
                btnStart.Text = "Stop";
                isClicked = !isClicked;
            }
            else
            {
                btnStart.Text = "Start";
                btnSend.Enabled = false;
                source.Cancel();
                if (Socket != null)
                    Socket.Close();
                isClicked = !isClicked;
            }
        }

        private async void HandleClient(Socket client)
        {
            this.Invoke((MethodInvoker)(() => { listBox1.Items.Add($"{client.RemoteEndPoint} connected"); }));
            while (!token.IsCancellationRequested)
            {
                var arraySegment = new ArraySegment<byte>(new byte[1024]);
                await client.ReceiveAsync(arraySegment, SocketFlags.None);
                if (arraySegment.Count <= 0) return;
                var buff = arraySegment.ToArray();
                string message = Encoding.UTF8.GetString(buff);
                message = $"{client.RemoteEndPoint}: " + message;
                foreach (var item in Clients)
                {
                    if (item != client)
                        await item.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(message)), SocketFlags.None);
                }
                this.Invoke((MethodInvoker)(() => { listBox1.Items.Add(message); }));
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            source = new();
            token = source.Token;
            btnSend.Enabled = false;
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox2.Text) && Clients.Count != 0)
            {
                string message = "Server: " + textBox2.Text;
                var buf = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
                foreach (var item in Clients)
                {
                    await item.SendAsync(buf, SocketFlags.None);
                }
                listBox1.Items.Add(textBox2.Text);
                textBox2.Text = "";
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            source.Cancel();
            if (Socket != null)
                Socket.Close();
        }
    }
}
