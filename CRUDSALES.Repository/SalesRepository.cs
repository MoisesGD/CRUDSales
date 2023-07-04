using CRUDSales.Entity.Models;
using CRUDSALES.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Repository
{
	public class SalesRepository : PostestRepository<Sale>, ISalesRepository
	{
		public SalesRepository(PostestContext context) : base(context)
		{
		}
		public async Task<Sale> AddSale(Sale sale)
		{
			Context.Sales.Add(sale);
			await Context.SaveChangesAsync(default);
			return sale;
		}

		
		public Task<List<Sale>> GetSales(DateTime startTime, DateTime endTime)
		{
			return Context.Sales.Include(c => c.Customer).Include(c => c.Concepts).ThenInclude(p =>p.Product)
				.Where(d => d.Date >= startTime && d.Date <= endTime).ToListAsync();
		}
	}
}
