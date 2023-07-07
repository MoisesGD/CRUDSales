using CRUDSales.Entity.Models;
using CRUDSALES.DTO;
using CRUDSALES.Interfaces.Repositories;
using CRUDSALES.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Service
{
	public class ClientsService : IClientsService
	{
		protected readonly IClientsRepository _clientsRepository;
		public ClientsService(IClientsRepository clientsRepository)
		{ 
			_clientsRepository= clientsRepository;
		}
		public async Task<Customer> AddCurstomer(CustomerForm customerForm)
		{
			var customer = new Customer();
			customer.Name = customerForm.Name;
			return await _clientsRepository.AddCurstomer(customer);
		}

		public async Task<Customer> GetCustomer(int customerId)
		{
			return await _clientsRepository.GetCustomer(customerId);
		}

		public async Task<List<Customer>> GetCustomers()
		{
			return await _clientsRepository.GetCustomers();
		}
	}
}
