using ProductApp.DAL;
using System;
using System.Web.Http;

namespace ProductApp.API.Controllers
{
    public interface IProductController<T> : IApiController<T> where T : Product
    {
        ResultObject GetListBySupplier(int supplierId, int page, int size);
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
            try
            { 
                if (context.Products.Contains(id))
                {
                    return new ResultObject(true, context.Products.Get(id).ToViewModel());
                }
                return new ResultObject(false, null, "Id not found");
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public ResultObject GetAll()
        {
            try
            { 
                return new ResultObject(true, context.Products.GetAll().ToViewModel(), context.Products.Count());
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpGet]
        [Route("GetListPaging/{page}/{size}")]
        public ResultObject GetListPaging(int page, int size)
        {
            try
            { 
                int total = 1;
                return new ResultObject(true, context.Products.GetListPaging(out total, page, size).ToViewModel(), total);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpGet]
        [Route("GetListPaging/{page}/{size}/{searchKey}")]
        public ResultObject GetListPaging(int page, int size, string searchKey)
        {
            try
            {
                int total = 1;
                return new ResultObject(true, context.Products.GetListPaging(out total, page, size, searchKey).ToViewModel(), total);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpGet]
        [Route("GetListBySupplier/{supplierId}/{page}/{size}")]
        public ResultObject GetListBySupplier(int supplierId, int page, int size)
        {
            try
            { 
                if (context.Suppliers.Contains(supplierId))
                {
                    int total = 1;
                    return new ResultObject(true, context.Products.GetListBySupplier(supplierId, out total, page, size).ToViewModel(), total);
                }
                return new ResultObject(false, null, "SupplierId not found");
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpPost]
        [Route("Insert")]
        public ResultObject Insert([FromBody]Product req)
        {
            try
            { 
                return new ResultObject(true, context.Products.Add(req).Id);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]Product req)
        {
            try
                { 
                if (context.Products.Contains(req.Id))
                {
                    return new ResultObject(true, context.Products.Update(req));
                }
                return new ResultObject(false, null, "Id not found");
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ResultObject Delete(int id)
        {
            try
            { 
                if (context.Products.Contains(id))
                {
                    return new ResultObject(true, context.Products.Delete(id));
                }
                return new ResultObject(false, null, "Id not found");
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }
    }
}