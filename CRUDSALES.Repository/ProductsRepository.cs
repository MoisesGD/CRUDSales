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
	public class ProductsRepository : PostestRepository<Product>, IProductsRepository
	{
		public ProductsRepository(IPostestContext context) : base(context)
		{
		}
		public async Task<Product> AddProducts(Product product)
		{
			Context.Products.Add(product);
			await Context.SaveChangesAsync(default);
			return product;
		}

		public async Task<Product> GetProduct(int productId)
		{
			var product = await Context.Products.FindAsync(productId);
			return product;
		}

		public async Task<List<Product>> GetProducts()
		{
			return await Context.Products.ToListAsync();
			
		}
	}
}
