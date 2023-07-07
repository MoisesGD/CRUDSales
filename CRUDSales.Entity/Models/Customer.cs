using System;
using System.Collections.Generic;

namespace CRUDSales.Entity.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        public int CustomerId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
