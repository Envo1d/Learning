using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_HW3.Core
{
    public class Game
    {
        private bool Finded { get; set; } = false;
        private bool IsHost { get; set; }
        private List<byte> CheckedBoxes { get; set; }
        private Client Client { get; set; }

        public Game()
        {
            CheckedBoxes = new();
            Client = new(10102);
        }
    }
}
