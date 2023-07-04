using System;
using System.Collections.Generic;

namespace CRUDSales.Entity.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public byte[] UnitPrice { get; set; } = null!;

    public decimal Cost { get; set; }

    public virtual ICollection<Concept> Concepts { get; set; } = new List<Concept>();
}
