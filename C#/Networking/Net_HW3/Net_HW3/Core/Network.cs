using SimpleTcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Net_HW3.Core
{
    public class Network
    {
        private UdpClient UdpClient { get; set; }
        private SimpleTcpClient? TcpClient { get; set; }
        private SimpleTcpServer? TcpServer { get; set; }
        private IPAddress? Address { get; set; }
        private IPAddress? LocalIP { get; set; }
        private string? ClientInfo { get; set; }
        private int? TcpPort { get; set; }

        public Network(int udpPort)
        {
            UdpClient = new UdpClient(udpPort);
            UdpClient.EnableBroadcast = true;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    LocalIP = ip;
                }
            }
        }

        protected void ClearData()
        {
            UdpClient.Close();
            UdpClient.Dispose();
            if (TcpClient != null)
            {
                TcpClient.Disconnect();
                TcpClient.Dispose();
            }
            if (TcpServer != null && TcpServer.IsListening)
            {
                TcpServer.Stop();
                TcpServer.Dispose();
            }
        }
    }
}
