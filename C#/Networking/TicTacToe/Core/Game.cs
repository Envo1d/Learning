using SuperSimpleTcp;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TicTacToe.Core
{
    public class Game
    {
        public struct PlayerType
        {
            public static string First_Player = "/circle.png";
            public static string Second_Player = "/cross.png";
        }

        public enum MessageType : byte
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

        public string Player { get; set; }
        private List<byte> CheckedBoxes { get; set; }
        private UdpClient? UdpClient { get; set; }
        private SimpleTcpClient? TcpClient { get; set; }
        private SimpleTcpServer? TcpServer { get; set; }
        public bool PlayerFinded { get; set; } = false;
        public IPAddress Address { get; set; }
        private IPAddress LocalIP { get; set; }
        private string ClientInfo { get; set; }
        public int TcpPort { get; set; }
        public bool IsHost { get; set; }
        private IAsyncResult BroadcastResult { get; set; }
        private IPEndPoint Pair { get; set; }
        public SimpleTcpClientEvents TcpClientEvents { get; set; }
        public SimpleTcpServerEvents TcpServerEvents { get; set; }

        public Game()
        {
            CheckedBoxes = new();
            CreateUdp();
            TcpClientEvents = new();
            TcpServerEvents = new();

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    LocalIP = ip;
                }
            }
        }

        private void CreateUdp()
        {
            UdpClient = new UdpClient(10102);
            UdpClient.EnableBroadcast = true;
        }

        private void DisposeUdp()
        {
            if(UdpClient != null)
            {
                UdpClient.Close();
                UdpClient.Dispose();
                UdpClient = null;
            }
        }

        private void DisposeTcp()
        {
            if (TcpClient != null)
            {
                TcpClient.Disconnect();
                TcpClient.Dispose();
                TcpClient = null;
            }
            if (TcpServer != null && TcpServer.IsListening)
            {
                TcpServer.Stop();
                TcpServer.Dispose();
                TcpServer = null;
            }
        }

        private void CloseConnection()
        {
            DisposeUdp();
            DisposeTcp();
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

        public bool StartBroadcastReceive()
        {
            var timeToWait = TimeSpan.FromSeconds(5);
            BroadcastResult = UdpClient.BeginReceive(null, null);
            BroadcastResult.AsyncWaitHandle.WaitOne(timeToWait);
            return BroadcastResult.IsCompleted;
        }

        public async Task<bool> EndBroadcastReveive()
        {
            try
            {
                IPEndPoint? tmp = null;
                var data = UdpClient.EndReceive(BroadcastResult, ref tmp);
                if (data[0] == (byte)MessageType.Free)
                {
                    Address = tmp.Address;
                    IsHost = false;
                    return false;
                }
                else
                {
                    await UdpClient.SendAsync(new byte[1] {(byte)MessageType.Free}, 1, tmp.Address.ToString(), tmp.Port);
                    Pair = tmp;
                    IsHost = true;
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> SendSearchAlert()
        {
            await UdpClient.SendAsync(new byte[1] { (byte)MessageType.LookingForGame }, 1, "192.168.0.255", 10102);
            return true;
        }

        public async Task<bool> SendPort()
        {
            TcpPort = 5000;
            byte[] portData = Encoding.UTF8.GetBytes(TcpPort.ToString());
            await UdpClient.SendAsync(portData, portData.Length, Pair);
            return true;
        }

        public async Task<bool> GetPort()
        {
        getPort:
            BroadcastResult = UdpClient.BeginReceive(null, null);
            var timeToWait = TimeSpan.FromSeconds(5);
            BroadcastResult.AsyncWaitHandle.WaitOne(timeToWait);
            if (BroadcastResult.IsCompleted)
            {
                try
                {
                    IPEndPoint tmp = null;
                    var data = UdpClient.EndReceive(BroadcastResult, ref tmp);
                    if(data.Length > 1) {
                        TcpPort = Convert.ToInt32(Encoding.UTF8.GetString(data));
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                goto getPort;
            }
            return false;
        }

        public async Task<byte> Step(byte boxNum)
        {
            bool win = false;
            CheckedBoxes.Add(boxNum);
            if (DiagonalWinCondition() || HorizontalWinCondition() || VerticalWinCondition())
                win = true;
            if (IsHost)
                await TcpServer.SendAsync(ClientInfo, new byte[1] { CheckedBoxes.Last() });
            else
                await TcpClient.SendAsync(new byte[1] { CheckedBoxes.Last() });
            if(win)
            {
                if (IsHost)
                    await TcpServer.SendAsync(ClientInfo, new byte[1] { (byte)MessageType.PlayerWin });
                else
                    await TcpClient.SendAsync(new byte[1] { (byte)MessageType.PlayerWin });
                return Convert.ToByte(win);
            }
            return Convert.ToByte(2);
        }

        public void EndGame()
        {
            CheckedBoxes.Clear();
            CloseConnection();
        }

        public async Task<bool> Connect()
        {
            if (IsHost)
            {
                TcpServer = new SimpleTcpServer(LocalIP.ToString(), TcpPort);
                await TcpServer.StartAsync();
                TcpServer.Events = TcpServerEvents;
                TcpServerEvents.ClientConnected += Events_ClientConnected;
                TcpServerEvents.ClientDisconnected += Events_ClientDisconnected;
                TcpServerEvents.DataReceived += Events_DataReceived;
                Player = PlayerType.First_Player;
                return await Task.Run(() =>
                {
                    byte counter = 0;
                    bool flag = false;
                    while (counter <= 10)
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
                        return false;
                    }
                    else return true;
                });
            }
            else
            {
                Player = PlayerType.Second_Player;
                TcpClient = new SimpleTcpClient(Address.ToString(), TcpPort);
                TcpClient.Events = TcpClientEvents;
                TcpClientEvents.Connected += Events_Connected;
                try
                {
                    TcpClient.ConnectWithRetries(10000);
                    TcpClientEvents.DataReceived += Events_DataReceived;
                    return true;
                }
                catch (Exception)
                { 
                    TcpClient.Dispose();
                    return false;
                }
            }
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            byte[]? data = e.Data.ToArray();
            if(data != null) {
                if (data[0] >= (byte)MessageType.CheckedBox1 && data[0] <= (byte)MessageType.CheckedBox9)
                {
                    CheckedBoxes.Add(data[0]);
                }
            }
        }

        private void Events_Connected(object? sender, ConnectionEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            TcpServer?.Stop();
            TcpServer?.Dispose();
        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            ClientInfo = e.IpPort;
        }
    }
}
