using System;
using System.Collections.Generic;

namespace GraduateWork.DB.Entity
{
    public partial class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
            SuppliedProducts = new HashSet<SuppliedProduct>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Model { get; set; } = null!;
        public decimal Price { get; set; }
        public byte? Unit { get; set; }
        public int ProducerId { get; set; }

        public virtual Producer Producer { get; set; } = null!;
        public virtual Unit? UnitNavigation { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<SuppliedProduct> SuppliedProducts { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Model}";
        }
    }
}
