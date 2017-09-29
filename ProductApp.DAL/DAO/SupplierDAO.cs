using ProductApp.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProductApp.DAL.DAO
{
    public interface ISupplierDAO : IRepository<Supplier>
    {
        IEnumerable<Supplier> GetListPaging(out int total, int page = 0, int size = 50, Expression<Func<Supplier, bool>> expression = null, string[] includes = null);
    }
    public class SupplierDAO : RepositoryBase<Supplier>, ISupplierDAO
    {
        public SupplierDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public virtual IEnumerable<Supplier> GetAll(string[] includes = null)
            => GetAll(o => o.OrderBy(s => s.CompanyName));

        public virtual IEnumerable<Supplier> GetListPaging(out int total, int page = 0, int size = 50, Expression<Func<Supplier, bool>> expression = null, string[] includes = null)
            => GetListPaging(o => o.OrderBy(s => s.CompanyName), out total, page, size, expression, includes);
    }
}