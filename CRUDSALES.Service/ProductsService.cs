using CRUDSales.Entity.Models;
using CRUDSALES.DTO;
using CRUDSALES.Interfaces.Repositories;
using CRUDSALES.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Service
{
	public class ProductsService : IProductsService
	{
		protected readonly IProductsRepository _productsRepository;
		public ProductsService(IProductsRepository productsRepository)
		{
			_productsRepository= productsRepository;
		}
		public async Task<Product> AddProducts(ProductForm productForm)
		{
			var product = new Product();
			product.Name = productForm.Name;
			product.UnitPrice = productForm.UnitPrice;
			product.Cost = productForm.Cost;

			return await _productsRepository.AddProducts(product);
		}

		public async Task<Product> GetProduct(int productId)
		{
			return await _productsRepository.GetProduct(productId);
		}

		public async Task<List<Product>> GetProducts()
		{
			return await _productsRepository.GetProducts();
		}
	}
}
