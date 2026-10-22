using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HW5.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
