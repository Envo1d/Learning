using System;
using System.Collections.Generic;

namespace GraduateWork.DB.Entity
{
    public partial class Supplier
    {
        public Supplier()
        {
            SuppliedProducts = new HashSet<SuppliedProduct>();
        }

        public int SupplierId { get; set; }
        public string Name { get; set; } = null!;
        public int AddressId { get; set; }
        public string Phone { get; set; } = null!;
        public string Bank { get; set; } = null!;
        public string Bill { get; set; } = null!;

        public virtual Address Address { get; set; } = null!;
        public virtual ICollection<SuppliedProduct> SuppliedProducts { get; set; }
    }
}
