using ProductApp.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProductApp.DAL.DAO
{
    public interface IOrderItemDAO : IRepository<OrderItem>
    {
        IEnumerable<OrderItem> GetListPaging(out int total, int page = 0, int size = 50, Expression<Func<OrderItem, bool>> expression = null, string[] includes = null);

        IEnumerable<OrderItem> GetListByOrder(int orderId, out int total, int page = 0, int size = 50, string[] includes = null);
       
    }

    public class OrderItemDAO : RepositoryBase<OrderItem>, IOrderItemDAO
    {
        public OrderItemDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public virtual IEnumerable<OrderItem> GetListByOrder(int orderId, out int total, int page = 0, int size = 50, string[] includes = null)
            => GetListPaging(o => o.OrderBy(or => or.Id), out total, page, size, o => o.OrderId == orderId, includes);

        public virtual IEnumerable<OrderItem> GetListPaging(out int total, int page = 0, int size = 50, Expression<Func<OrderItem, bool>> expression = null, string[] includes = null)
            => GetListPaging(o => o.OrderBy(or => or.Id), out total, page, size, expression, includes);
    }
}