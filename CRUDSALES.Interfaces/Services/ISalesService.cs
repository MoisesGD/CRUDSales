﻿using CRUDSales.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Interfaces.Services
{
	public interface ISalesService
	{
		Task<Sale> AddSale(Sale sale);
		Task<List<Sale>> GetSales(DateTime startTime, DateTime endTime);
	}
}
