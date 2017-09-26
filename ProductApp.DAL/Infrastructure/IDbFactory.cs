using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.DAL.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ProductsEntities Init();
    }
}
