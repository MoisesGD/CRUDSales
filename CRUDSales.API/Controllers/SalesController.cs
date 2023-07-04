using CRUDSales.Entity.Models;
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

		public async Task<IActionResult> Get([FromQuery]DateTime startDate, DateTime endDate)
		{
			return Ok(await _salesService.GetSales(startDate,endDate));


		}
		[HttpPost]
		public async Task<IActionResult> Post(Sale sale)
		{
			return Ok(await _salesService.AddSale(sale));


		}
	}
}
