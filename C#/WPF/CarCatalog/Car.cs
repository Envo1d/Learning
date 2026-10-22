using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public Types Type { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
    }

    public enum Types
    {
        Sedan,
        Coupe,
        Sport,
        StationWagon,
        Hatchback,
        Minivan
    }
}
