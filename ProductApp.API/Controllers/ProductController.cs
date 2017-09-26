using ProductApp.DAL;
using System.Web.Http;

namespace ProductApp.API.Controllers
{
    public interface IProductController<T> where T : Product
    {
        ResultObject Get(int id);

        ResultObject GetAll();

        ResultObject GetListPaging(int page, int size);

        ResultObject GetListBySupplier(int supplierId, int page, int size);

        ResultObject Insert([FromBody]T req);

        ResultObject Update([FromBody]T req);

        ResultObject Delete(int id);
    }

    [RoutePrefix("api/product")]
    public class ProductController : ApiController, IProductController<Product>
    {
        private ProductContext context;

        public ProductController()
        {
            context = new ProductContext();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ResultObject Get(int id)
        {
            if (context.Products.Contains(id))
            {
                return new ResultObject(true, context.Products.Get(id).ToViewModel());
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public ResultObject GetAll()
        {
            return new ResultObject(true, context.Products.GetAll().ToViewModel(), context.Products.Count());
        }

        [HttpGet]
        [Route("GetListPaging/{page}/{size}")]
        public ResultObject GetListPaging(int page, int size)
        {
            int total = 1;
            return new ResultObject(true, context.Products.GetListPaging(out total, page, size).ToViewModel(), total);
        }

        [HttpGet]
        [Route("GetListBySupplier/{supplierId}/{page}/{size}")]
        public ResultObject GetListBySupplier(int supplierId, int page, int size)
        {
            if (context.Suppliers.Contains(supplierId))
            {
                //int total = 1;
                //return new ResultObject(true, context.Orders.GetListByCustomer(customerId, out total, page, size), total);
                int total = 1;
                return new ResultObject(true, context.Products.GetListBySupplier(supplierId, out total, page, size).ToViewModel(), total);
            }
            return new ResultObject(false, "", "SupplierId not found");
        }

        [HttpPost]
        [Route("Insert")]
        public ResultObject Insert([FromBody]Product req)
        {
            return new ResultObject(true, context.Products.Add(req).Id);
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]Product req)
        {
            if (context.Products.Contains(req.Id))
            {
                return new ResultObject(true, context.Products.Update(req));
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ResultObject Delete(int id)
        {
            if (context.Products.Contains(id))
            {
                return new ResultObject(true, context.Products.Delete(id));
            }
            return new ResultObject(false, "", "Id not found");
        }
    }
}