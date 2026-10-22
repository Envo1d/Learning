using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HW4.Domain.Entities
{
    public class QuestRoom
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Quest { get; set; }
        public string Details { get; set; }
        public int DifficultyId { get; set; }
        public Difficulty Difficulty { get; set; }
        public int FearLevelId { get; set; }
        public FearLevel FearLevel { get; set; }
        public int PlayersNumberId { get; set; }
        public PlayersNumber PlayersNumber { get; set; }
    }
}
