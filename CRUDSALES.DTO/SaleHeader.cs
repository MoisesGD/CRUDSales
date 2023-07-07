using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.DTO
{
	public class SaleHeader
	{
		public int ID { get; set; }
		public DateTime Date{ get; set; }
		public int CustomerId { get; set; }
		public decimal Total { get; set; }
		public bool Active { get; set; }

	}
}
