using ProductApp.DAL;
using System;
using System.Web.Http;

namespace ProductApp.API.Controllers
{
    public interface ICustomerController : IApiController<Customer>
    {

    }

    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController, ICustomerController
    {
        private ProductContext context;

        public CustomerController()
        {
            context = new ProductContext();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ResultObject Get(int id)
        {
            try
            { 
                if (context.Customers.Contains(id))
                {
                    return new ResultObject(true, context.Customers.Get(id).ToViewModel());
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
                return new ResultObject(true, context.Customers.GetAll().ToViewModel(), context.Customers.Count());
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
                return new ResultObject(true, context.Customers.GetListPaging(out total, page, size).ToViewModel(), total);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpPost]
        [Route("Insert")]
        public ResultObject Insert([FromBody]Customer req)
        {
            try
            { 
                return new ResultObject(true, context.Customers.Add(req).Id);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]Customer req)
        {
            try
                { 
                if (context.Customers.Contains(req.Id))
                {
                    return new ResultObject(true, context.Customers.Update(req));
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
                if (context.Customers.Contains(id))
                {
                    return new ResultObject(true, context.Customers.Delete(id));
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