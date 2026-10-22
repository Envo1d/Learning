using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using SimpleTcp;

namespace Net_HW3
{
    public partial class Form1 : Form
    {
        struct PlayerType
        {
            public static string First_Player = "/circle.png";
            public static string Second_Player = "/cross.png";
        }
        enum MessageType : byte
        {
            CheckedBox1 = 1,
            CheckedBox2 = 2,
            CheckedBox3 = 3,
            CheckedBox4 = 4,
            CheckedBox5 = 5,
            CheckedBox6 = 6,
            CheckedBox7 = 7,
            CheckedBox8 = 8,
            CheckedBox9 = 9,
            ConnectionEstablished = 10,
            EndpointSaved = 11,
            PlayerWin = 12,
            Restart = 13,
            Waiting = 14,
            Free = 15,
            LookingForGame = 16
        }

        private const string path = "./Assets";
        private string Player { get; set; }
        private List<byte> CheckedBoxes { get; set; }
        private UdpClient UdpClient { get; set; }
        private EndPoint EndPoint { get; set; }
        private SimpleTcpClient TcpClient { get; set; }
        private SimpleTcpServer TcpServer { get; set; }
        private CancellationToken Token { get; set; }
        private CancellationTokenSource Source { get; set; }
        private bool FindClicked { get; set; } = false;
        private IPAddress Address { get; set; }
        private IPAddress LocalIP { get; set; }
        private string ClientInfo { get; set; }
        private int TcpPort { get; set; }
        private bool IsGeneral { get; set; }
        private Task Game { get; set; }


        public Form1()
        {
            InitializeComponent();    
            #region Events
            box1.MouseEnter += BoxMouseEnter;
            box1.MouseLeave += BoxMouseLeave;
            box1.Click += BoxClick;
            box2.MouseEnter += BoxMouseEnter;
            box2.MouseLeave += BoxMouseLeave;
            box2.Click += BoxClick;
            box3.MouseEnter += BoxMouseEnter;
            box3.MouseLeave += BoxMouseLeave;
            box3.Click += BoxClick;
            box4.MouseEnter += BoxMouseEnter;
            box4.MouseLeave += BoxMouseLeave;
            box4.Click += BoxClick;
            box5.MouseEnter += BoxMouseEnter;
            box5.MouseLeave += BoxMouseLeave;
            box5.Click += BoxClick;
            box6.MouseEnter += BoxMouseEnter;
            box6.MouseLeave += BoxMouseLeave;
            box6.Click += BoxClick;
            box7.MouseEnter += BoxMouseEnter;
            box7.MouseLeave += BoxMouseLeave;
            box7.Click += BoxClick;
            box8.MouseEnter += BoxMouseEnter;
            box8.MouseLeave += BoxMouseLeave;
            box8.Click += BoxClick;
            box9.MouseEnter += BoxMouseEnter;
            box9.MouseLeave += BoxMouseLeave;
            box9.Click += BoxClick;
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckedBoxes = new();
            UdpClient = new UdpClient(10102);
            UdpClient.EnableBroadcast = true;
            Source = new();
            Token = Source.Token;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            panel2.Enabled = false;
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    LocalIP =  ip;
                }
            }
            btnPlay.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Source.Cancel();
            UdpClient.Close();
            UdpClient.Dispose();
            if (TcpClient != null)
            {
                TcpClient.Disconnect();
                TcpClient.Dispose();
            }
            if(TcpServer != null && TcpServer.IsListening)
            {
                TcpServer.Stop();
                TcpServer.Dispose();
            }
        }

        private async void BoxClick(object? sender, EventArgs e)
        {
            bool win = false;
            (sender as PictureBox).Image = Image.FromFile(path + Player);
            (sender as PictureBox).Enabled = false;
            CheckedBoxes.Add(Convert.ToByte((sender as PictureBox).Name.Substring(3)));
            if (DiagonalWinCondition())
               win = true;
            if (HorizontalWinCondition())
               win = true;
            if (VerticalWinCondition())
                win = true;
            //else
            //{
                if (IsGeneral)
                    await TcpServer.SendAsync(ClientInfo, new byte[1] { CheckedBoxes.Last() });
                else
                    await TcpClient.SendAsync(new byte[1] { CheckedBoxes.Last() });
            //  }
            if (win)
            {
                if (IsGeneral)
                    await TcpServer.SendAsync(ClientInfo, new byte[1] { (byte)MessageType.PlayerWin });
                else
                    await TcpClient.SendAsync(new byte[1] { (byte)MessageType.PlayerWin });
                GameResult(win);
            }
            panel2.Enabled = false;
        }

        private void BoxMouseLeave(object? sender, EventArgs e)
        {
            (sender as PictureBox).BackColor = Color.Gray;
        }

        private void BoxMouseEnter(object? sender, EventArgs e)
        {
            (sender as PictureBox).BackColor = Color.White;
        }

        private bool DiagonalWinCondition()
        {
            if (CheckedBoxes.Any(val => val == 1) && CheckedBoxes.Any(val => val == 5) && CheckedBoxes.Any(val => val == 9))
                return true;
            else if (CheckedBoxes.Any(val => val == 3) && CheckedBoxes.Any(val => val == 5) && CheckedBoxes.Any(val => val == 7))
                return true;
            else return false;
        }
        private bool HorizontalWinCondition()
        {
            if (CheckedBoxes.Any(val => val == 1) && CheckedBoxes.Any(val => val == 2) && CheckedBoxes.Any(val => val == 3))
                return true;
            else if (CheckedBoxes.Any(val => val == 4) && CheckedBoxes.Any(val => val == 5) && CheckedBoxes.Any(val => val == 6))
                return true;
            else if (CheckedBoxes.Any(val => val == 7) && CheckedBoxes.Any(val => val == 8) && CheckedBoxes.Any(val => val == 9))
                return true;
            else return false;
        }
        private bool VerticalWinCondition()
        {
            if (CheckedBoxes.Any(val => val == 1) && CheckedBoxes.Any(val => val == 4) && CheckedBoxes.Any(val => val == 7))
                return true;
            else if (CheckedBoxes.Any(val => val == 2) && CheckedBoxes.Any(val => val == 5) && CheckedBoxes.Any(val => val == 8))
                return true;
            else if (CheckedBoxes.Any(val => val == 3) && CheckedBoxes.Any(val => val == 6) && CheckedBoxes.Any(val => val == 9))
                return true;
            else return false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!FindClicked)
            {
                Task.Run(async () =>
                {
                    this.Invoke((Action)(() => { infLbl.Text = "Ищем пару"; }));
                    UdpClient.EnableBroadcast = true;

                    var timeToWait = TimeSpan.FromSeconds(5);
                    IPEndPoint pair = null;
                    search:
                    var asyncRes = UdpClient.BeginReceive(null, null);
                    asyncRes.AsyncWaitHandle.WaitOne(timeToWait);
                    if (asyncRes.IsCompleted)
                    {
                        try
                        {
                            this.Invoke((Action)(() => { infLbl.Text = "Пара найдена"; }));
                            IPEndPoint tmp = null;
                            var data = UdpClient.EndReceive(asyncRes, ref tmp);
                            if (data[0] == (byte)MessageType.Free)
                            {
                                this.Invoke((Action)(() => { infLbl.Text = $"Подключение к {tmp.Address}"; }));
                                Address = tmp.Address;
                                IsGeneral = false;
                            }
                            else
                            {
                                await UdpClient.SendAsync(new byte[1] { (byte)MessageType.Free }, 1, tmp.Address.ToString(), tmp.Port);
                                pair = tmp;
                                IsGeneral = true;
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                    else
                    {
                       await UdpClient.SendAsync(new byte[1] { (byte)MessageType.LookingForGame }, 1, "192.168.0.255", 10102);
                        goto search;
                    }
                    if (IsGeneral)
                    {
                        TcpPort = 5000;
                        byte[] portData = Encoding.UTF8.GetBytes($"{TcpPort}");
                        this.Invoke((Action)(() => { infLbl.Text = $"Отправка порта"; }));
                        await UdpClient.SendAsync(portData, portData.Length, pair);
                        await Task.Delay(1000);
                    }
                    else
                    {
                    getPort:
                        asyncRes = UdpClient.BeginReceive(null, null);
                        asyncRes.AsyncWaitHandle.WaitOne(timeToWait);
                        if (asyncRes.IsCompleted)
                        {
                            try
                            {
                                IPEndPoint tmp = null;
                                var data = UdpClient.EndReceive(asyncRes, ref tmp);
                                if (data.Length > 1)
                                {
                                    this.Invoke((Action)(() => { infLbl.Text = $"Порт: {Encoding.UTF8.GetString(data)}"; }));
                                    TcpPort = Convert.ToInt32(Encoding.UTF8.GetString(data));
                                }
                            }
                            catch (Exception ex)
                            { }
                        }
                        else
                        {
                            goto getPort;
                        }
                    }
                    FindClicked = !FindClicked;
                   
                    this.Invoke((Action)(() => {
                        btnStart.Text = "Поиск пары";
                        btnStart.Enabled = false;
                        btnPlay.Enabled = true;
                    }));
                }, Token);
                btnStart.Text = "Стоп";
                FindClicked = !FindClicked;
            }
            else
            {
                btnStart.Text = "Поиск пары";
                infLbl.Text = "Pending";
                FindClicked = !FindClicked;
                Source.Cancel();
                Source = new();
                Token = Source.Token;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsGeneral)
            {
                TcpServer = new SimpleTcpServer(LocalIP.ToString(), TcpPort);
                TcpServer.StartAsync();
                TcpServer.Events.ClientConnected += Events_ClientConnected;
                TcpServer.Events.ClientDisconnected += Events_ClientDisconnected;
                TcpServer.Events.DataReceived += Events_DataReceived;
                panel2.Enabled = true;
                Player = PlayerType.First_Player;
                Task.Run(() =>
                {
                    byte counter = 0;
                    bool flag = false;
                    while(counter <= 10)
                    {
                        var check = TcpServer.GetClients().ToList();
                        if (check.Count != 0)
                        {
                            flag = true;
                            break;
                        }
                        Thread.Sleep(1000);
                        counter++;
                    }
                    if (!flag)
                    {
                        TcpServer.Stop();
                        TcpServer.Dispose();
                        this.Invoke((Action)(() =>
                        {
                            infLbl.Text = "Не удалось установить соединение с клиентом";
                            btnPlay.Enabled = false;
                            btnStart.Enabled = true;
                        }));
                    }
                    else GameStart();
                });
            }
            else
            {
                Player = PlayerType.Second_Player;
                TcpClient = new SimpleTcpClient(Address.ToString(), TcpPort);
                TcpClient.Events.Connected += Events_Connected;
                try
                {
                    TcpClient.ConnectWithRetries(10000);
                    TcpClient.Events.DataReceived += Events_DataReceived;
                    GameStart();
                }
                catch (Exception ex) { infLbl.Text = "Не удалось установить соединение с сервером";
                    btnPlay.Enabled = false;
                    btnStart.Enabled = true;
                    TcpClient.Dispose();
                }
            }
        }

        private void Events_Connected(object? sender, ClientConnectedEventArgs e)
        {
            this.Invoke((Action)(() => {
                infLbl.Text = $"Connected to {Address}:{TcpPort}";
            }));
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            var data = e.Data.ToArray();
            if (data[0] >= (byte)MessageType.CheckedBox1 && data[0] <= (byte)MessageType.CheckedBox9)
            {
                CheckedBoxes.Add(data[0]);
                if(IsGeneral)
                {
                    this.Invoke((Action)(() => {
                        PictureBox bpx = Controls.Find($"box{data[0]}", true).First() as PictureBox;
                         bpx.Image = Image.FromFile(path + PlayerType.Second_Player);
                        bpx.Enabled = false;
                    }));
                }
                else
                {
                    this.Invoke((Action)(() => {
                        PictureBox bpx = Controls.Find($"box{data[0]}", true).First() as PictureBox;
                        bpx.Image = Image.FromFile(path + PlayerType.First_Player);
                        bpx.Enabled = false;
                    }));
                }
                this.Invoke((Action)(() => panel2.Enabled = true));
            }
            else if(data[0] == (byte)MessageType.PlayerWin)
            {
                GameResult(false);
            }
        }

        private void Events_ClientDisconnected(object? sender, ClientDisconnectedEventArgs e)
        {
            this.Invoke((Action)(() => infLbl.Text = e.IpPort.ToString() + " Disconnected"));
            TcpServer.Stop();
            TcpServer.Dispose();
        }

        private void Events_ClientConnected(object? sender, ClientConnectedEventArgs e)
        {
            this.Invoke((Action)(() => infLbl.Text = e.IpPort.ToString() + " Connected"));
            ClientInfo = e.IpPort;
        }
        private void GameStart()
        {
            box1.BackColor = Color.Gray;
            box2.BackColor = Color.Gray;
            box3.BackColor = Color.Gray;
            box4.BackColor = Color.Gray;
            box5.BackColor = Color.Gray;
            box6.BackColor = Color.Gray;
            box7.BackColor = Color.Gray;
            box8.BackColor = Color.Gray;
            box9.BackColor = Color.Gray;
            this.Invoke((Action)(() => { btnPlay.Enabled = false; }));
        }
        private void GameResult(bool res)
        {
            if(res)
                MessageBox.Show("You Win", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("You Lose", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Invoke((Action)(() =>
            {
                panel2.Enabled = false;
                CheckedBoxes.Clear();
                box1.Image = null;
                box2.Image = null;
                box3.Image = null;
                box4.Image = null;
                box5.Image = null;
                box6.Image = null;
                box7.Image = null;
                box8.Image = null;
                box9.Image = null;
                box1.Enabled = true;
                box2.Enabled = true;
                box3.Enabled = true;
                box4.Enabled = true;
                box5.Enabled = true;
                box6.Enabled = true;
                box7.Enabled = true;
                box8.Enabled = true;
                box9.Enabled = true;
                btnPlay.Enabled = false;
                btnStart.Enabled = true;
                infLbl.Text = "Pending";
                if (Player == PlayerType.Second_Player)
                {
                    TcpClient.Disconnect();
                    TcpClient.Dispose();
                }
                else if(Player == PlayerType.First_Player && TcpServer.GetClients().ToList().Count != 0)
                {
                    TcpServer.Stop();
                    TcpServer.Dispose();
                }
            }));
        }
    }
}
