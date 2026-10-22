using System;
using System.Collections.Generic;

namespace GraduateWork.DB.Entity
{
    public partial class SuppliedProduct
    {
        public int SupplyId { get; set; }
        public DateTime SupDate { get; set; }
        public int Amount { get; set; }
        public int OriginalAmount { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
    }
}
