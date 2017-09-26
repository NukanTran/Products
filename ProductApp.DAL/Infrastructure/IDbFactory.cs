using System;

namespace ProductApp.DAL.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ProductsEntities Init();
    }
}