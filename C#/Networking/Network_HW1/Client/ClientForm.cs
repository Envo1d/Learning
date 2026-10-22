using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        Socket Socket { get; set; }
        bool isClicked = false;
        CancellationToken token;
        CancellationTokenSource source;
        Task Listening { get; set; }
        public ClientForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            btnSend.Enabled = false;
            source = new();
            token = source.Token;
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (!isClicked)
            {
                IPAddress add;
                if (!string.IsNullOrEmpty(textBox3.Text) && IPAddress.TryParse(textBox3.Text, out add))
                {
                    var end = new IPEndPoint(add, (int)numericUpDown1.Value);
                    await Socket.ConnectAsync(end);
                    btnConnect.Text = "Disconnect";
                    btnSend.Enabled = true;
                    Listening = Task.Run(async () =>
                    {
                        var arraySegment = new ArraySegment<byte>(new byte[1024]);
                        while (!token.IsCancellationRequested)
                        {
                            await Socket.ReceiveAsync(arraySegment, SocketFlags.None);
                            var buff = arraySegment.ToArray();
                            this.Invoke((MethodInvoker)(() => { listBox1.Items.Add(Encoding.UTF8.GetString(buff)); }));
                        }
                    }, token);
                    isClicked = !isClicked;
                }
            }
            else
            {
                btnSend.Enabled = false;
                btnConnect.Text = "Conntect";
                Socket.Close();
                source.Cancel();
                isClicked = !isClicked;
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && Socket != null)
            {
                await Socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(textBox2.Text)), SocketFlags.None);
                listBox1.Items.Add(textBox2.Text);
                textBox2.Text = "";
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Socket.Close();
            source.Cancel();
        }
    }
}
