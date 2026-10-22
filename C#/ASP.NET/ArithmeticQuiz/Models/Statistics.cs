using ASP_HW2.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HW2.Models
{
    public class Statistics : ISaver
    {
        public Dictionary<string, int> Results { get; set; } = new();
    }
}
