using CRUDSales.Entity.Models;
using CRUDSALES.Interfaces.Repositories;
using CRUDSALES.Interfaces.Services;
using CRUDSALES.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Service
{
	public class SalesService : ISalesService
	{
		protected readonly ISalesRepository _salesRepository;
		public SalesService(ISalesRepository salesRepository)
		{
			_salesRepository= salesRepository;
		}
		public async Task<Sale> AddSale(Sale sale)
		{
			return await _salesRepository.AddSale(sale);
		}

		public async Task<List<Sale>> GetSales(DateTime startTime, DateTime endTime)
		{
			return await _salesRepository.GetSales(startTime, endTime);
		}
	}
}
