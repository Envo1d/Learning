using System;
using System.Collections.Generic;

namespace GraduateWork.DB.Entity
{
    public partial class Seller
    {
        public Seller()
        {
            Sales = new HashSet<Sale>();
        }

        public int SellerId { get; set; }
        public string FullName { get; set; } = null!;
        public int AddressId { get; set; }
        public string Phone { get; set; } = null!;

        public virtual Address Address { get; set; } = null!;
        public virtual ICollection<Sale> Sales { get; set; }

        public override string ToString()
        {
            return $"{SellerId} - {FullName}";
        }
    }
}
