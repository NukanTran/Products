using ProductApp.DAL.Infrastructure;

namespace ProductApp.DAL.DAO
{
    public class SupplierDAO : RepositoryBase<Supplier>
    {
        public SupplierDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}