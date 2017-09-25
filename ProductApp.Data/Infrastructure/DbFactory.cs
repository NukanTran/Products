using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ProductsEntities context;

        public ProductsEntities Init()
        {
            return context ?? (context = new ProductsEntities());
        }

        protected override void DisposeCore()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
