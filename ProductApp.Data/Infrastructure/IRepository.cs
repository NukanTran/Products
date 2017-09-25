using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        bool Update(int id, T entity);
        void Delete(T entity);
        void Delete(int id);
        T Get(int id);
        IQueryable<T> GetAll();
        IQueryable<T> GetListPaging(int page, int size);
        int Count();
        bool Contains(int id);
    }
}
