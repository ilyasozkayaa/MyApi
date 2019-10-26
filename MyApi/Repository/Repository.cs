using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApi.Model.Context;

namespace MyApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context dbContext;
        public Repository(Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public DbSet<T> Table { get; set; }


        public bool Add(T entity)
        {
            Table.Add(entity);
            return Save();
        }

        public IQueryable<T> All()
        {
            return Table;
        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return Save();
        }

        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return Table.OrderByDescending(orderBy);
            return Table.OrderBy(orderBy);
        }

        public bool Update(T entity)
        {
            Table.Update(entity);
            return Save();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return Table.Where(where);
        }
        private bool Save()
        {
            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                // TODO: Log Exceptions
                return false;
            }
        }
    }
}
