using ProductApp.DAL;
using System;
using System.Web.Http;

namespace ProductApp.API.Controllers
{
    public interface IOrderController : IApiController<Order>
    {

        ResultObject GetListByCustomer(int supplierId, int page, int size);

        ResultObject GetListByDate(string fromDate, string toDate, int page, int size);
    }

    [RoutePrefix("api/order")]
    public class OrderController : ApiController, IOrderController
    {
        private ProductContext context;

        private OrderController()
        {
            context = new ProductContext();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ResultObject Get(int id)
        {
            try
            { 
                if (context.Orders.Contains(id))
                {
                    return new ResultObject(true, context.Orders.Get(id).ToViewModel());
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
                return new ResultObject(true, context.Orders.GetAll().ToViewModel(), context.Orders.Count());
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
                return new ResultObject(true, context.Orders.GetListPaging(out total, page, size).ToViewModel(), total);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpGet]
        [Route("GetListByCustomer/{customerId}/{page}/{size}")]
        public ResultObject GetListByCustomer(int customerId, int page, int size)
        {
            try
            { 
                int total = 1;
                return new ResultObject(true, context.Orders.GetListByCustomer(customerId, out total, page, size).ToViewModel(), total);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpGet]
        [Route("GetListByDate/{fromDate}/{toDate}/{page}/{size}")]
        public ResultObject GetListByDate(string fromDate, string toDate, int page, int size)
        {
            try
            {
                var format = "dd-MM-yyyy";
                var from = DateTime.ParseExact(fromDate, format, null);
                var to = DateTime.ParseExact(toDate, format, null);
                int total = 1;
                return new ResultObject(true, context.Orders.GetListByDate(from, to, out total, page, size).ToViewModel(), total);
            }
            catch (FormatException e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpPost]
        [Route("Insert")]
        public ResultObject Insert([FromBody]Order req)
        {
            try
            { 
                return new ResultObject(true, context.Orders.Add(req).Id);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]Order req)
        {
            try
            { 
                if (context.Orders.Contains(req.Id))
                {
                    return new ResultObject(true, context.Orders.Update(req));
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
                if (context.Orders.Contains(id))
                {
                    return new ResultObject(true, context.Orders.Delete(id));
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