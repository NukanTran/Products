using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.Data.Infrastructure;

namespace ProductApp.Data.DAO
{
    public class ClotheDAO : ProductDAO
    {
        public ClotheDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
