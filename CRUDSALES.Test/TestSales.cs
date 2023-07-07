using CRUDSales.Entity.Models;
using CRUDSALES.Interfaces.Repositories;
using CRUDSALES.Interfaces.Services;
using CRUDSALES.Repository;
using CRUDSALES.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSales.Test
{
	public class TestSales
	{
		private readonly SalesService _salesServiceTest;
		private readonly Mock<ISalesRepository> _salesRepositoryMock = new Mock<ISalesRepository>();
		public TestSales()

		{
			_salesServiceTest = new SalesService(_salesRepositoryMock.Object);
		}
		[Fact]
		public async Task GetSales()
		{

			var salesList = new List<Sale>()
			{
				new Sale() {
					Date= DateTime.Now,
					CustomerId= 1,
					SaleId=1,
					Active=true,
					Total=10
					
					
				}
			};
			var startDay = DateTime.Now;
			var endDay = DateTime.Now.AddDays(-1);

			_salesRepositoryMock.Setup(x => x.GetSales(startDay, endDay)).ReturnsAsync(salesList);


			var cs = await _salesServiceTest.GetSales(startDay, endDay);
			Assert.NotNull(cs);

		}
		[Fact]
		public async Task CancelSale()
		{
			var salesList =
			
				new Sale() {
					Date= DateTime.Now,
					CustomerId= 1,
					SaleId=1,
					Active=false,
					Total=10


			};
			


			_salesRepositoryMock.Setup(x => x.CancellSale(1)).ReturnsAsync(salesList);

			var cs = await _salesServiceTest.CancellSale(1);
			Assert.NotNull(cs);
			Assert.True(cs.SaleHeader.Active == false);

		}
	}
}
