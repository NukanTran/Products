using ProductApp.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProductApp.DAL.DAO
{
    public interface ICustomerDAO : IRepository<Customer>
    {
        IEnumerable<Customer> GetListPaging(out int total, int page = 0, int size = 50, Expression<Func<Customer, bool>> expression = null, string[] includes = null);
    }
    public class CustomerDAO : RepositoryBase<Customer>, ICustomerDAO
    {
        public CustomerDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public virtual IEnumerable<Customer> GetListPaging(out int total, int page = 0, int size = 50, Expression<Func<Customer, bool>> expression = null, string[] includes = null)
            => GetListPaging(o => o.OrderBy(c => c.FirstName + c.LastName), out total, page, size, expression, includes);
    }
}