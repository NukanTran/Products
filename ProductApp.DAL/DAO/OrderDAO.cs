using ProductApp.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProductApp.DAL.DAO
{
    public interface IOrderDAO : IRepository<Order>
    {
        IEnumerable<Order> GetListPaging(out int total, int page = 0, int size = 50, Expression<Func<Order, bool>> expression = null, string[] includes = null);

        IEnumerable<Order> GetListByCustomer(int customerId, out int total, int page = 0, int size = 50, string[] includes = null);

        IEnumerable<Order> GetListByDate(DateTime from, DateTime to, out int total, int page = 0, int size = 50, string[] includes = null);
    }

    public class OrderDAO : RepositoryBase<Order>, IOrderDAO
    {
        public OrderDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public virtual IEnumerable<Order> GetListByCustomer(int customerId, out int total, int page = 0, int size = 50, string[] includes = null)
            => GetListPaging(o => o.OrderByDescending(or => or.OrderDate), out total, page, size, o => o.CustomerId == customerId, includes);

        public virtual IEnumerable<Order> GetListByDate(DateTime from, DateTime to, out int total, int page = 0, int size = 50, string[] includes = null)
            => GetListPaging(o => o.OrderByDescending(or => or.OrderDate), out total, page, size, o => o.OrderDate >= from && o.OrderDate <= to, includes);

        public virtual IEnumerable<Order> GetListPaging(out int total, int page = 0, int size = 50, Expression<Func<Order, bool>> expression = null, string[] includes = null)
            => GetListPaging(o => o.OrderByDescending(or => or.OrderDate), out total, page, size, expression, includes);
    }
}