using ProductApp.DAL.Infrastructure;

namespace ProductApp.DAL.DAO
{
    public class PhoneDAO : ProductDAO<Product_Phone>
    {
        public PhoneDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}