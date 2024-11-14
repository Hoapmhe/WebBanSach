using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BanSach.DataAccess.Data;

namespace BanSach.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        internal DbSet<T> DbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            this.DbSet = _context.Set<T>();
        }
        void IRepository<T>.Add(T item)
        {
            DbSet.Add(item);
        }

        public void Delete(T item)
        {
            DbSet.Remove(item); ;
        }

        IEnumerable<T> IRepository<T>.GetAll(Expression<Func<T, bool>>? filter = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                     string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public T GetItem(Expression<Func<T, bool>> filter, string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault();
        }
    }
}
