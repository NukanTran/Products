using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.DAL.Infrastructure;

namespace ProductApp.DAL.DAO
{
    public class ClotheDAO : ProductDAO<Product_Clothe>
    {
        public ClotheDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        
    }
}
