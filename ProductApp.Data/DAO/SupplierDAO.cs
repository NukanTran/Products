using ProductApp.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Data.DAO
{
    public class SupplierDAO : RepositoryBase<Supplier>
    {
        public SupplierDAO(IDbFactory dbFactory) : base(dbFactory)
        {

        }


    }
}
