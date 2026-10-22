using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_HW5.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public int FileId { get; set; }
        public File File { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
