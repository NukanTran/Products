using ProductApp.DAL.Infrastructure;

namespace ProductApp.DAL.DAO
{
    public class CustomerDAO : RepositoryBase<Customer>
    {
        public CustomerDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}