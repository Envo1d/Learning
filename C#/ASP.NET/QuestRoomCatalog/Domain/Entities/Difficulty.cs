using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HW4.Domain.Entities
{
    public class Difficulty
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Numeric { get; set; }
        public ICollection<QuestRoom> QuestRooms { get; set; }
    }
}
