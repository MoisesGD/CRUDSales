using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.DTO
{
	public class SaleForm
	{
		public SaleHeader SaleHeader { get; set; } = new SaleHeader();
		public List<ConceptsForm> ConceptsForm { get; set; } = new List<ConceptsForm>();
	}
}
