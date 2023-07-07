using System;
using System.Collections.Generic;

namespace CRUDSales.Entity.Models
{
    public partial class Sale
    {
        public Sale()
        {
            Concepts = new HashSet<Concept>();
        }

        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public bool? Active { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Concept> Concepts { get; set; }
    }
}
