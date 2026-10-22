using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_HW3.Core
{
    public class Client: Network
    {
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



        public Client(int udpPort): base(udpPort)
        {

        }
    }
}
