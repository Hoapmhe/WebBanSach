using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BanSach.DataAccess.Repository { 
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
                                     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                     string includeProperties = "");
        T GetItem(Expression<Func<T, bool>> filter, string includeProperties = "");
        void Add(T item);
        void Delete(T item);
    }
}
