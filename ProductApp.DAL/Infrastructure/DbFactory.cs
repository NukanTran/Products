namespace ProductApp.DAL.Infrastructure
{
    internal class DbFactory : IDbFactory
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