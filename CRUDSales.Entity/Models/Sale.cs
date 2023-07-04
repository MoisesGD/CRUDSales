using System;
using System.Collections.Generic;

namespace CRUDSales.Entity.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public DateTime Date { get; set; }

    public int CustomerId { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<Concept> Concepts { get; set; } = new List<Concept>();

    public virtual Customer Customer { get; set; } = null!;
}
