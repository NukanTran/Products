using ProductApp.DAL;
using System;
using System.Web.Http;

namespace ProductApp.API.Controllers
{
    public interface ISupplierController : IApiController<Supplier>
    {

    }

    [RoutePrefix("api/supplier")]
    public class SupplierController : ApiController, ISupplierController
    {
        private ProductContext context;

        public SupplierController()
        {
            context = new ProductContext();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ResultObject Get(int id)
        {
            try
            { 
                if (context.Suppliers.Contains(id))
                {
                    return new ResultObject(true, context.Suppliers.Get(id).ToViewModel());
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
                return new ResultObject(true, context.Suppliers.GetAll().ToViewModel(), context.Suppliers.Count());
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
                return new ResultObject(true, context.Suppliers.GetListPaging(out total, page, size).ToViewModel(), total);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpPost]
        [Route("Insert")]
        public ResultObject Insert([FromBody]Supplier req)
        {
            try
            { 
                return new ResultObject(true, context.Suppliers.Add(req).Id);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]Supplier req)
        {
            try
                { 
                if (context.Suppliers.Contains(req.Id))
                {
                    return new ResultObject(true, context.Suppliers.Update(req));
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
                if (context.Suppliers.Contains(id))
                {
                    return new ResultObject(true, context.Suppliers.Delete(id));
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