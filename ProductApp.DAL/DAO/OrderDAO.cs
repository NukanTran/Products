using ProductApp.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.DAL.DAO
{
    public class OrderDAO : RepositoryBase<Order>
    {
        public OrderDAO(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
