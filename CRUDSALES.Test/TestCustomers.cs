using CRUDSales.Entity.Models;
using CRUDSALES.DTO;
using CRUDSALES.Interfaces.Repositories;
using CRUDSALES.Service;
using Moq;

namespace CRUDSales.Test
{
	public class TestCustomers
	{
		private readonly ClientsService _clientsServiceTest;
		private readonly Mock<IClientsRepository> _clientRepositoryMock = new Mock<IClientsRepository>();

		public TestCustomers() 
		
		{
			_clientsServiceTest = new ClientsService(_clientRepositoryMock.Object);
		}
		[Fact]
		public async Task GetClients()
		{

			var customerList = new List<Customer>()
			{
				new Customer() {
					CustomerId= 1,
					Name = "ElMoi",
					Sales = null
				}
			};

			_clientRepositoryMock.Setup(x => x.GetCustomers()).ReturnsAsync(customerList);


			var cs = await  _clientsServiceTest.GetCustomers();
			Assert.NotNull(cs);

		}
		[Fact]
		public async Task GetClient()
		{
			var customerList = new Customer() {
					CustomerId= 1,
					Name = "ElMoi",
					Sales = null
				};
		

			_clientRepositoryMock.Setup(x => x.GetCustomer(1)).ReturnsAsync(customerList);

			var cs = await _clientsServiceTest.GetCustomer(1);
			Assert.NotNull(cs);

		}
		//[Fact]
		//public async Task AddClient()
		//{
			
			
		//	var customerSend= new Customer()
		//	{
				
		//		Name = "ElMoi",
				
		//	};
		//	var customerBack = new Customer()
		//	{
		//		CustomerId = 1,
		//		Name = "ElMoi",
		//		Sales = null

		//	};


		//	_clientRepositoryMock.Setup(a => a.AddCurstomer(customerSend)).ReturnsAsync(customerBack);


		//	var cs = await _clientsServiceTest.AddCurstomer(new CustomerForm { Name=customerSend.Name });
		//	Assert.NotNull(cs);

		//}
	}
}