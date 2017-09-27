using ProductApp.DAL.Infrastructure;

namespace ProductApp.DAL.DAO
{
    public interface IPhoneDAO : IRepository<Product_Phone>
    {

    }

    public class PhoneDAO : ProductDAO<Product_Phone>, IPhoneDAO
    {
        public PhoneDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}