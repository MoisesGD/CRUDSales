using CRUDSales.Entity.Models;
using CRUDSALES.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDSales.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientsController : ControllerBase
	{
		protected readonly IClientsService _clientsService;
		public ClientsController(IClientsService clientsService)
		{
			_clientsService= clientsService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _clientsService.GetCustomers());


		}
		[HttpGet]
		[Route("{customerId}")]
		public async Task<IActionResult> Get(int customerId)
		{
			return Ok(await _clientsService.GetCustomer(customerId));


		}
		[HttpPost]
		public async Task<IActionResult> Post(Customer curstomer)
		{
			return Ok(await _clientsService.AddCurstomer(curstomer));


		}
	}
}
