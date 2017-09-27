using ProductApp.DAL;
using System;
using System.Web.Http;

namespace ProductApp.API.Controllers
{
    [RoutePrefix("api/product/clothe")]
    public class ClotheController : ApiController, IProductController<Product_Clothe>
    {
        private ProductContext context;

        public ClotheController()
        {
            context = new ProductContext();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ResultObject Get(int id)
        {
            try
            {
                if (context.Clothes.Contains(id))
                {
                    return new ResultObject(true, context.Clothes.Get(id).ToViewModel());
                }
                return new ResultObject(false, null, "Id not found");
            }
            catch(Exception e)
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
                return new ResultObject(true, context.Clothes.GetAll().ToViewModel(), context.Clothes.Count());
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
                return new ResultObject(true, context.Clothes.GetListPaging(out total, page, size).ToViewModel(), total);
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
                    return new ResultObject(true, context.Clothes.GetListBySupplier(supplierId, out total, page, size).ToViewModel(), total);
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
        public ResultObject Insert([FromBody]Product_Clothe req)
        {
            try
            { 
                return new ResultObject(true, context.Clothes.Add(req).Id);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]Product_Clothe req)
        {
            try
            { 
                if (context.Clothes.Contains(req.Id))
                {
                    return new ResultObject(true, context.Clothes.Update(req));
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
                if (context.Clothes.Contains(id))
                {
                    return new ResultObject(true, context.Clothes.Delete(id));
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