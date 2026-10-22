using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        private enum DeviceCap
        {
            Desktopvertres = 117,
            Desktophorzres = 118
        }

        public static Size GetPhysicalDisplaySize()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();

            int physicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.Desktopvertres);
            int physicalScreenWidth = GetDeviceCaps(desktop, (int)DeviceCap.Desktophorzres);

            return new Size(physicalScreenWidth, physicalScreenHeight);
        }

        static Size ScreenSize { get; set; }
        const int PacketSize = 65000;

        static async Task Main(string[] args)
        {
            Socket udpSocket = new Socket(AddressFamily.InterNetwork,
                     SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Loopback, 10_000);
            EndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            udpSocket.Bind(ep);
            while (true)
            {
                ScreenSize = GetPhysicalDisplaySize();
                
                bool f = false;
                while (true)
                {
                    Console.WriteLine("Waiting connection");
                    var message = new byte[3];
                    try
                    {
                        udpSocket.ReceiveFrom(message, SocketFlags.None, ref sender);
                        if (Encoding.UTF8.GetString(message) == "ack")
                        {
                            f = true;
                            break;
                        }
                    }
                    catch { }
                }
                if (f)
                {
                    Console.WriteLine("Start Sending");
                    var data = new byte[PacketSize + 2];
                    var captureBmp = new System.Drawing.Bitmap(ScreenSize.Width, ScreenSize.Height, System.Drawing.Imaging.PixelFormat.Format64bppArgb);
                    using (var captureGraphic = Graphics.FromImage(captureBmp))
                    {
                        captureGraphic.CopyFromScreen(0, 0, 0, 0, captureBmp.Size);
                        using (MemoryStream ms = new())
                        {
                            captureBmp.Save(ms, ImageFormat.Jpeg);
                            byte[] img = ms.ToArray();
                            var packets = Math.Floor((decimal)img.Length / data.Length);
                            for (int i = 0; i <= packets; i++)
                            {
                                var start = i * PacketSize;
                                var end = start + PacketSize;
                                if (end > img.Length)
                                {
                                    end = img.Length;
                                }
                                Array.Clear(data, 0, data.Length);
                                data[0] = (byte)i;
                                data[1] = (byte)packets;
                                Console.WriteLine($"{i}) [{start}, {end}] Len: {end - start + 2}");
                                Array.Copy(img, start, data, 2, end - start);
                                try
                                {
                                    await udpSocket.SendToAsync(data, SocketFlags.None, sender);
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
        }
    }
}
