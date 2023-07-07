using CRUDSales.Entity.Models;
using CRUDSALES.Interfaces.Context;
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
		public SalesRepository(IPostestContext context) : base(context)
		{
		}
		public async Task<Sale> AddSale(Sale sale)
		{
			Context.Sales.Add(sale);
			await Context.SaveChangesAsync(default);
			return sale;
		}


		public async Task<List<Sale>> GetSales(DateTime startTime, DateTime endTime)
		{
			return await Context.Sales.Include(c => c.Customer).Include(c => c.Concepts).ThenInclude(p => p.Product)
				.Where(d => d.Date >= startTime && d.Date <= endTime).ToListAsync();
		}
		public async Task<Sale> GetSale(int saleId)
		{
			return await Context.Sales.FirstOrDefaultAsync(f => f.SaleId.Equals(saleId));
		}
		public async Task<Sale> CancellSale(int saleId)
		{
			var sale = await GetSale(saleId);

			sale.Active =false;
			await Context.SaveChangesAsync(default);
			return sale;
		}
	}
}
