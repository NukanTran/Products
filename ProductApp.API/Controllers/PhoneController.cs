using ProductApp.DAL;
using System;
using System.Web.Http;

namespace ProductApp.API.Controllers
{
    [RoutePrefix("api/product/phone")]
    public class PhoneController : ApiController, IProductController<Product_Phone>
    {
        private ProductContext context;

        public PhoneController()
        {
            context = new ProductContext();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ResultObject Get(int id)
        {
            try
            {
                if (context.Phones.Contains(id))
                {
                    return new ResultObject(true, context.Phones.Get(id).ToViewModel());
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
                return new ResultObject(true, context.Phones.GetAll().ToViewModel(), context.Phones.Count());
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
                return new ResultObject(true, context.Phones.GetListPaging(out total, page, size).ToViewModel(), total);
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
                    return new ResultObject(true, context.Phones.GetListBySupplier(supplierId, out total, page, size).ToViewModel(), total);
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
        public ResultObject Insert([FromBody]Product_Phone req)
        {
            try
            { 
                return new ResultObject(true, context.Phones.Add(req).Id);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]Product_Phone req)
        {
            try
            {
                if (context.Phones.Contains(req.Id))
                {
                    return new ResultObject(true, context.Phones.Update(req));
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
                if (context.Phones.Contains(id))
                {
                    return new ResultObject(true, context.Phones.Delete(id));
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