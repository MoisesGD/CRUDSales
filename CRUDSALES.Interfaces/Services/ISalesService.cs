using CRUDSales.Entity.Models;
using CRUDSALES.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Interfaces.Services
{
	public interface ISalesService
	{
		Task<SaleForm> AddSale(SaleForm sale);
		Task<List<SaleForm>> GetSales(DateTime startTime, DateTime endTime);
		Task<SaleForm> CancellSale(int saleId);
	}
}
