using System;
using System.Collections.Generic;

namespace GraduateWork.DB.Entity
{
    public partial class Unit
    {
        public Unit()
        {
            Products = new HashSet<Product>();
        }

        public byte UnitId { get; set; }
        public string UnitName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
