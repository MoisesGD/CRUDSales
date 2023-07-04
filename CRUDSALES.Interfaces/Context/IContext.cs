using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Interfaces.Context
{
	public interface IContext
	{
		DbSet<TEntity> Set<TEntity>() where TEntity : class;

		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
		EntityEntry Entry(object entity);
		void Dispose();
	}
}
