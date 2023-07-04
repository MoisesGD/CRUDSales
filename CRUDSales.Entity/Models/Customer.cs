using System;
using System.Collections.Generic;

namespace CRUDSales.Entity.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public byte[] Name { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
