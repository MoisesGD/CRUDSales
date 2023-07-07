using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.DTO
{
	public class ProductForm
	{
		public int ID { get; set; }	
		public string Name { get; set; } = string.Empty;
		public string UnitPrice { get; set; } = string.Empty;
		public decimal Cost { get; set; }
	}
}
