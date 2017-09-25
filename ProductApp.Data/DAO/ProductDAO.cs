using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.Data.Infrastructure;

namespace ProductApp.Data.DAO
{
    public class ProductDAO : RepositoryBase<Product>
    {
        public ProductDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
