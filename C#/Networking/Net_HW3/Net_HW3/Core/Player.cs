using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_HW3.Core
{
    public class Player
    {
        public struct PlayerType
        {
            public static string First_Player = "/circle.png";
            public static string Second_Player = "/cross.png";
        }
        private string PlayerData { get; set; }
    }
}
