using ProductApp.DAL.Infrastructure;

namespace ProductApp.DAL.DAO
{
    public class ClotheDAO : ProductDAO<Product_Clothe>
    {
        public ClotheDAO(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}