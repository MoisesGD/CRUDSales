using CRUDSales.Entity.Models;
using CRUDSALES.DTO;
using CRUDSALES.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDSales.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SalesController : ControllerBase
	{

		protected readonly ISalesService _salesService;
		public SalesController(ISalesService salesService)
		{
			_salesService= salesService;
		}
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery]DateTime startDate, DateTime endDate)
		{
			return Ok(await _salesService.GetSales(startDate,endDate));


		}

		[HttpPost]
		public async Task<IActionResult> Post(SaleForm sale)
		{
			return Ok(await _salesService.AddSale(sale));


		}
		[HttpPut]
		[Route("{saleId}")]
		public async Task<IActionResult> Cancell(int saleId)
		{
			return Ok(await _salesService.CancellSale(saleId));


		}
	}
}
