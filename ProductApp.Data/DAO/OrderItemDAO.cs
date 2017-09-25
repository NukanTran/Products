using ProductApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Data.DAO
{
    public class OrderItemDAO : RepositoryBase<OrderItem>
    {
        public OrderItemDAO(IDbFactory dbFactory) : base(dbFactory)
        {

        }


    }
}
