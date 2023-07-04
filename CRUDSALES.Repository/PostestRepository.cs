
using CRUDSALES.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSALES.Repository
{
	public class PostestRepository<TEntity> : IRepository<TEntity>
										where TEntity : class
	{
		protected readonly IPostestContext Context;
		public PostestRepository(IPostestContext context)
		{
			Context = context;
		}
		public void Add(TEntity entity)
		{
			Context.Set<TEntity>().Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().AddRange(entities);
		}

		public void Deleted(TEntity entity)
		{
			throw new NotImplementedException();
		}

		public void Edit(TEntity entity)
		{
			Context.Entry(entity).State = EntityState.Deleted;
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return Context.Set<TEntity>().Where(predicate).ToList<TEntity>();
		}

		public TEntity Get(int id)
		{
			return Context.Set<TEntity>().Find(id);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return Context.Set<TEntity>().ToList();
		}

		public void Remove(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			Context.Set<TEntity>().RemoveRange(entities);
		}

		public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			return Context.Set<TEntity>().SingleOrDefault(predicate);
		}
	}
}
