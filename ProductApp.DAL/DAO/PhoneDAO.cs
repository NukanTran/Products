using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProductApp.DAL.Infrastructure;

namespace ProductApp.DAL.DAO
{
    public class PhoneDAO : ProductDAO<Product_Phone>
    {
        public PhoneDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
