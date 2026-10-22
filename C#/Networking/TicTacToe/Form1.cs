using SuperSimpleTcp;
using System.Net;
using TicTacToe.Core;
using static TicTacToe.Core.Game;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private Game game;
        private const string path = "./Assets";
        private CancellationToken Token { get; set; }
        private CancellationTokenSource Source { get; set; }

        public Form1()
        {
            InitializeComponent();

            game = new Game();

            Source = new();
            Token = Source.Token;

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
            panel2.Enabled = false;
            btnPlay.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.EndGame();
            Source.Cancel();
        }

        private async void BoxClick(object? sender, EventArgs e)
        {
            (sender as PictureBox).Image = Image.FromFile(path + game.Player);
            (sender as PictureBox).Enabled = false;
            byte res = await game.Step(Convert.ToByte((sender as PictureBox).Name.Substring(3)));
            if (res != 2)
            {
                GameResult(res);
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!game.PlayerFinded)
            {
                Task.Run(async () =>
                {
                    bool res = game.StartBroadcastReceive();
                search:
                    if (res)
                    {
                        Invoke(() => { infLbl.Text = "Player finded"; });
                        if (await game.EndBroadcastReveive() == false)
                        {
                            Invoke(() => { infLbl.Text = $"Connecting to {game.Address}"; });
                        }
                    }
                    else
                    {
                        await game.SendSearchAlert();
                        goto search;
                    }
                    if (game.IsHost)
                    {
                        Invoke(() => { infLbl.Text = $"Sending port"; });
                        await game.SendPort();
                        await Task.Delay(1000);
                    }
                    else
                    {
                        if (await game.GetPort())
                        {
                            Invoke(() => { infLbl.Text = $"Port: {game.TcpPort}"; });
                        }
                    }
                }, Token);
                btnStart.Text = "Stop";
                Invoke(() => { infLbl.Text = "Pending"; });
                game.PlayerFinded = !game.PlayerFinded;
            }
            else
            {
                btnStart.Text = "Find player";
                infLbl.Text = "No info";
                game.PlayerFinded = false;
                Source.Cancel();
                Source = new();
                Token = Source.Token;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (game.IsHost)
            {
                panel2.Enabled = true;
                if (await game.Connect() == false)
                    Invoke(() =>
                    {
                        infLbl.Text = "Failed to establish connection with client";
                        btnPlay.Enabled = false;
                        btnStart.Enabled = true;
                    });
                else
                {
                    game.TcpServerEvents.ClientConnected += Events_ClientConnected;
                    game.TcpServerEvents.ClientDisconnected += Events_ClientDisconnected;
                    game.TcpServerEvents.DataReceived += Events_DataReceived;
                    GameStart();
                }
            }
            else
            {
                if (await game.Connect() == false)
                    Invoke(() =>
                    {
                        infLbl.Text = "Failed to establish connection with host";
                        btnPlay.Enabled = false;
                        btnStart.Enabled = true;
                    });
                else
                {
                    game.TcpClientEvents.Connected += Events_Connected;
                    game.TcpClientEvents.DataReceived += Events_DataReceived;
                    GameStart();
                }
            }
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
            Invoke(() => { btnPlay.Enabled = false; });
        }

        private void GameResult(byte res)
        {
            if (res == 1)
                MessageBox.Show("You Win", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("You Lose", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Invoke(() =>
            {
                panel2.Enabled = false;
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
                game.EndGame();
            });
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            var data = e.Data.ToArray();
            if (data[0] >= (byte)MessageType.CheckedBox1 && data[0] <= (byte)MessageType.CheckedBox9)
            {
                if (game.IsHost)
                {
                    this.Invoke((Action)(() =>
                    {
                        PictureBox bpx = Controls.Find($"box{data[0]}", true).First() as PictureBox;
                        bpx.Image = Image.FromFile(path + PlayerType.Second_Player);
                        bpx.Enabled = false;
                    }));
                }
                else
                {
                    this.Invoke((Action)(() =>
                    {
                        PictureBox bpx = Controls.Find($"box{data[0]}", true).First() as PictureBox;
                        bpx.Image = Image.FromFile(path + PlayerType.First_Player);
                        bpx.Enabled = false;
                    }));
                }
                this.Invoke((Action)(() => panel2.Enabled = true));
            }
            else if (data[0] == (byte)MessageType.PlayerWin)
            {
                GameResult(1);
            }
        }

        private void Events_Connected(object? sender, ConnectionEventArgs e)
        {
            Invoke((Action)(() => infLbl.Text = $"Connected to {game.Address}:{game.TcpPort}"));
        }

        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            Invoke((Action)(() => infLbl.Text = e.IpPort.ToString() + " Disconnected"));
        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            Invoke((Action)(() => infLbl.Text = e.IpPort.ToString() + " Connected"));
        }
    }
}