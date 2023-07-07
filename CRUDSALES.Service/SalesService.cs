using CRUDSales.Entity.Models;
using CRUDSALES.DTO;
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
		public async Task<SaleForm> AddSale(SaleForm saleForm)
		{
			SaleForm saleForms = new SaleForm();
			var sale = new Sale();
			sale.Date = saleForm.SaleHeader.Date;
			sale.CustomerId = saleForm.SaleHeader.CustomerId;
			sale.Total = saleForm.SaleHeader.Total;
			sale.Active= saleForm.SaleHeader.Active;
			var concepts = new List<Concept>();

			saleForm.ConceptsForm.ForEach(c =>
			{

				concepts.Add(new Concept()
				{
					Quantity= c.Quantity,
					ProductId = c.ProductId,
					UnitPrice= c.UnitPrice,
					Amount= c.Amount,


				});



			});
			sale.Concepts = concepts;


			sale = await _salesRepository.AddSale(sale);

			

			if (sale != null)
			{
				var conceptsForm = new List<ConceptsForm>();
				var consepts = sale.Concepts.ToList();

				consepts.ForEach(c =>
				{
					conceptsForm.Add(new ConceptsForm()
					{
						ID = c.ConceptId,
						Quantity =c.Quantity,
						ProductId= c.ProductId,
						SaleId= c.SaleId,
						UnitPrice= c.UnitPrice,
						Amount= c.Amount


					});
				});
				saleForms.SaleHeader = new SaleHeader()
				{
					ID = sale.SaleId,
					CustomerId = sale.CustomerId,
					Date = sale.Date,
					Total = sale.Total,
					Active = sale.Active??false,

				};
				saleForms.ConceptsForm = conceptsForm;

				

			}


			return saleForms;
		}

		public async Task<SaleForm> CancellSale(int saleId)
		{

			SaleForm saleForms = new SaleForm();
			var sale = await _salesRepository.CancellSale(saleId);
			if (sale != null)
			{
				var conceptsForm = new List<ConceptsForm>();
				var consepts = sale.Concepts.ToList();

				consepts.ForEach(c =>
				{
					conceptsForm.Add(new ConceptsForm()
					{
						ID = c.ConceptId,
						Quantity =c.Quantity,
						ProductId= c.ProductId,
						SaleId= c.SaleId,
						UnitPrice= c.UnitPrice,
						Amount= c.Amount


					});
				});
				saleForms.SaleHeader = new SaleHeader()
				{
					ID = sale.SaleId,
					CustomerId = sale.CustomerId,
					Date = sale.Date,
					Total = sale.Total,
					Active = sale.Active??false,

				};
				saleForms.ConceptsForm = conceptsForm;



			}



			return saleForms;
		}

		public async Task<List<SaleForm>> GetSales(DateTime startTime, DateTime endTime)
		{
			List<SaleForm> saleForms = new List<SaleForm>();
			var sale = await _salesRepository.GetSales(startTime, endTime); 

			var conceptsForm = new List<ConceptsForm>();

			sale.ForEach(s => {
				var consepts = s.Concepts.ToList();

				consepts.ForEach(c =>
				{
					conceptsForm.Add(new ConceptsForm()
					{
						ID = c.ConceptId,
						Quantity =c.Quantity,
						ProductId= c.ProductId,
						SaleId= c.SaleId,
						UnitPrice= c.UnitPrice,
						Amount= c.Amount


					});
				});
				saleForms.Add(new SaleForm()
				{
					SaleHeader = new SaleHeader()
					{
						ID = s.SaleId,
						CustomerId= s.CustomerId,
						Date= s.Date,
						Total = s.Total,
						Active = s.Active??false,

					},
					ConceptsForm = conceptsForm

				});


			});
			return saleForms;
			
		}
	}
}
