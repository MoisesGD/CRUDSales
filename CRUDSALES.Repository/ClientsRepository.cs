using CRUDSales.Entity.Models;
using CRUDSALES.Interfaces.Context;
using CRUDSALES.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Repository
{
	public class ClientsRepository: PostestRepository<Customer> , IClientsRepository
	{
		public ClientsRepository(IPostestContext context) : base(context)
		{
		}
		public async Task<Customer> AddCurstomer(Customer customer)
		{
			Context.Customers.Add(customer);
			await Context.SaveChangesAsync(default);
			return customer;

		}
		public async Task<List<Customer>> GetCustomers()
		{
			return await Context.Customers.ToListAsync();
		}
		public async Task<Customer> GetCustomer(int customerId)
		{
			var customer = await Context.Customers.FindAsync(customerId);
			return customer;
		}
	}
}
