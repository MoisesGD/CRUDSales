using CRUDSales.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Interfaces.Context
{
	public interface IPostestContext : IContext
	{
		 DbSet<Concept> Concepts { get; set; }
		DbSet<Customer> Customers { get; set; }
		DbSet<Product> Products { get; set; }
		DbSet<Sale> Sales { get; set; }
	}
}
