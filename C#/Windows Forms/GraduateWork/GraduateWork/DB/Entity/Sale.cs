namespace GraduateWork.DB.Entity
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public int SellerId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int SaledProductCount { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Price { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Seller Seller { get; set; } = null!;
    }
}
