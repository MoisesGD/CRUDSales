using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.DTO
{
	public class ConceptsForm
	{
		public int ID { get; set; }
		public decimal Quantity { get; set; }
		public int ProductId { get; set; }
		public int SaleId { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal Amount { get; set; }
	}
}
