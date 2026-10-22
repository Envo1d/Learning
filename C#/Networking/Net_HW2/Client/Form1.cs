using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private Socket Client { get; set; }
        private CancellationToken Token { get; set; }
        private CancellationTokenSource Source { get; set; }
        private int Delay { get; set; }
        private bool Clicked { get; set; }
        private IPEndPoint EndPoint { get; set; }
        private Dictionary<byte, byte[]> ImgData { get; set; }

        public Form1()
        {
            InitializeComponent();
            trackFps.Maximum = 20;
        }

        private void trackFps_Scroll(object sender, EventArgs e)
        {
            Delay = trackFps.Value;
            fps.Text = $"{Delay}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            EndPoint = new IPEndPoint(IPAddress.Loopback, 10_000);
            
            trackFps.Minimum = 1;
            trackFps.Value = 1;
            Delay = trackFps.Value;
            fps.Text = $"{Delay}";
            Clicked = false;
            ImgData = new();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!Clicked)
            {
                Source = new();
                Token = Source.Token;
                btnStart.Text = "Stop";
                Task.Run(async () =>
                {
                    while(true)
                    {
                        if (Token.IsCancellationRequested)
                            break;
                        await GetData();
                        Thread.Sleep(1000/Delay);
                    }
                }, Token);
                Clicked = !Clicked;
            }
            else
            {
                btnStart.Text = "Start";
                Source.Cancel();
                Clicked = !Clicked;
            }
        }

        private async Task GetData()
        {
            await Client.SendToAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes("ack")), SocketFlags.None, EndPoint);
            byte segment, totalSegments = 0;
            byte counter = 0;
            while (true)
            {
                if (Token.IsCancellationRequested)
                    break;
                var message = new ArraySegment<byte>(new byte[65002]);
                try
                {
                    await Client.ReceiveAsync(message, SocketFlags.None);
                }catch(Exception ex) 
                { 
                    break; 
                }
                byte[] buffer = message.Array;
                segment = buffer[0];
                totalSegments = buffer[1];
                ImgData.Add(segment, new byte[buffer.Length - 2]);
                Array.Copy(buffer, 2, ImgData[segment], 0, ImgData[segment].Length);
                counter++;
                if (counter - 1 == totalSegments)
                {
                    break;
                }
            }
            byte[] data = new byte[0];
            for (byte i = 0; i <= totalSegments; i++)
            {
                int idx = data.Length;
                if (!ImgData.ContainsKey(i)) continue;
                Array.Resize(ref data, data.Length + ImgData[i].Length);
                Array.Copy(ImgData[i], 0, data, idx, ImgData[i].Length);
            }
            ImgData.Clear();
            try
            {
                Image img = (Bitmap)((new ImageConverter()).ConvertFrom(data));
                this.Invoke((Action)(() => { picBox.Image = img; }));
            }
            catch { };
            Array.Clear(data, 0, data.Length);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Client.Shutdown(SocketShutdown.Both);
            Client.Close();
        }
    }
}
