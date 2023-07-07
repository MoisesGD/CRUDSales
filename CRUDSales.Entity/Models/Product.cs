using System;
using System.Collections.Generic;

namespace CRUDSales.Entity.Models
{
    public partial class Product
    {
        public Product()
        {
            Concepts = new HashSet<Concept>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? UnitPrice { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<Concept> Concepts { get; set; }
    }
}
