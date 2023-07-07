using CRUDSALES.DTO;
using CRUDSALES.Interfaces.Repositories;
using CRUDSALES.Service;
using CRUDSales.Entity.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSales.Test
{
	public  class TestProducts
	{
		private readonly ProductsService _productsServiceTest;
		private readonly Mock<IProductsRepository> _productsRepositoryMock = new Mock<IProductsRepository>();

		public TestProducts()

		{
			_productsServiceTest = new ProductsService(_productsRepositoryMock.Object);
		}
		[Fact]
		public async Task GetProducts()
		{

			var products = new List<Product>()
			{
				new Product()
				{

					ProductId= 1,
					Name = "ProductTest",
					Cost= 1,
					UnitPrice = "Pice",
					Concepts= null
				}
			};

			_productsRepositoryMock.Setup(x => x.GetProducts()).ReturnsAsync(products);

			var cs = await _productsServiceTest.GetProducts();
			Assert.NotNull(cs);

		}
		[Fact]
		public async Task GetProduct()
		{
			var product = new Product()
			{

					ProductId= 1,
					Name = "ProductTest",
					Cost= 1,
					UnitPrice = "Pice",
					Concepts= null
			
			};

			_productsRepositoryMock.Setup(x => x.GetProduct(1)).ReturnsAsync(product);
			var cs = await _productsServiceTest.GetProduct(1);
			Assert.NotNull(cs);

		}
		//[Fact]
		//public async Task AddProduct()
		//{
		//	var productForm = new ProductForm();
		//	productForm.Name = "Test Product";
		//	productForm.UnitPrice = "Pice";
		//	productForm.Cost = 10;

		//	var product = new Product()
		//	{

		//		ProductId= 1,
		//		Name = "ProductTest",
		//		Cost= 1,
		//		UnitPrice = "Pice",
		//		Concepts= null

		//	};
		//	var productB = new Product()
		//	{

				
		//		Name = "ProductTest",
		//		Cost= 1,
		//		UnitPrice = "Pice",
				

		//	};

		//	_productsRepositoryMock.Setup(x => x.AddProducts(productB)).ReturnsAsync(product);
		//	var cs = await _productsServiceTest.AddProducts(productForm);
		//	Assert.NotNull(cs);

		//}
	}
}
