using CRUDSales.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Interfaces.Repositories
{
	public interface IClientsRepository
	{
		Task<Customer> AddCurstomer(Customer customer);
		Task<List<Customer>> GetCustomers();
		Task<Customer> GetCustomer(int customerId);

	}
}
