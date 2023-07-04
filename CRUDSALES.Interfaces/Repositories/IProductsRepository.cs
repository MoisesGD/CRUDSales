using CRUDSales.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Interfaces.Repositories
{
	public interface IProductsRepository
	{
		Task<Product> AddProducts(Product product);
		Task<List<Product>> GetProducts();
		Task<Product> GetProduct(int productId);
	}
}
