using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.DAL.Infrastructure
{
    class DbFactory : IDbFactory
    {
        private ProductsEntities dbContext;

        public ProductsEntities Init()
        {
            return dbContext ?? (dbContext = new ProductsEntities());
        }
        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
