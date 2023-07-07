using CRUDSales.Entity.Models;
using CRUDSALES.DTO;
using CRUDSALES.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDSales.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		protected readonly IProductsService _productsService;
		public ProductsController(IProductsService productsService)
		{
			_productsService= productsService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _productsService.GetProducts());


		}
		[HttpGet]
		[Route("{productId}")]
		public async Task<IActionResult> Get(int productId)
		{
			return Ok(await _productsService.GetProduct(productId));


		}
		[HttpPost]
		public async Task<IActionResult> Post(ProductForm productForm)
		{
			return Ok(await _productsService.AddProducts(productForm));


		}
	}
}
