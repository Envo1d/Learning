using System;
using System.Collections.Generic;

namespace GraduateWork.DB.Entity
{
    public partial class Address
    {
        public Address()
        {
            Customers = new HashSet<Customer>();
            Producers = new HashSet<Producer>();
            Sellers = new HashSet<Seller>();
            Suppliers = new HashSet<Supplier>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string CountryName { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Producer> Producers { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
