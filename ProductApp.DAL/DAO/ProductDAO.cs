using ProductApp.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProductApp.DAL.DAO
{
    public interface IProductDAO<T> : IRepository<T> where T : Product
    {
        IEnumerable<T> GetListPaging(out int total, int page = 0, int size = 50, Expression<Func<T, bool>> expression = null, string[] includes = null);

        IEnumerable<T> GetListBySupplier(int supplierId, out int total, int page = 0, int size = 50, string[] includes = null);
    }

    public class ProductDAO<T> : RepositoryBase<T>, IProductDAO<T> where T : Product
    {
        public ProductDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public virtual IEnumerable<T> GetListPaging(out int total, int page = 0, int size = 50, Expression<Func<T, bool>> expression = null, string[] includes = null)
            => GetListPaging(o => o.OrderBy(p => p.ProductName), out total, page, size, expression, includes);

        public virtual IEnumerable<T> GetListBySupplier(int supplierId, out int total, int page = 0, int size = 50, string[] includes = null)
            => GetListPaging(o => o.OrderBy(p => p.ProductName), out total, page, size, p => p.SupplierId == supplierId, includes);
    }
}