using ProductApp.DAL.Infrastructure;

namespace ProductApp.DAL.DAO
{
    public class OrderItemDAO : RepositoryBase<OrderItem>
    {
        public OrderItemDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}