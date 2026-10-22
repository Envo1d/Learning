using System;
using System.Collections.Generic;

namespace GraduateWork.DB.Entity
{
    public partial class Producer
    {
        public Producer()
        {
            Products = new HashSet<Product>();
        }

        public int ProducerId { get; set; }
        public string Name { get; set; } = null!;
        public int AddressId { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual Address Address { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}
