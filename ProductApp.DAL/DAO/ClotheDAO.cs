using ProductApp.DAL.Infrastructure;

namespace ProductApp.DAL.DAO
{
    public interface IClotheDAO : IRepository<Product_Clothe>
    {

    }
    public class ClotheDAO : ProductDAO<Product_Clothe>, IClotheDAO
    {
        public ClotheDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}