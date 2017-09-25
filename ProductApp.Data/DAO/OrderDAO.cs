using ProductApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Data.DAO
{
    public class OrderDAO : RepositoryBase<Order>
    {
        public OrderDAO(IDbFactory dbFactory) : base(dbFactory)
        {

        }


    }
}
