using ProductApp.DAL;
using System;
using System.Web.Http;

namespace ProductApp.API.Controllers
{
    public interface IOrderController
    {
        ResultObject Get(int id);

        ResultObject GetAll();

        ResultObject GetListPaging(int page, int size);

        ResultObject GetListByCustomer(int supplierId, int page, int size);

        ResultObject GetListByDate(string fromDate, string toDate, int page, int size);

        ResultObject Insert([FromBody]Order req);

        ResultObject Update([FromBody]Order req);

        ResultObject Delete(int id);
    }

    [RoutePrefix("api/order")]
    public class OrderController : ApiController, IOrderController
    {
        private ProductContext context;

        private OrderController()
        {
            context = new ProductContext();
            context.SetLazyLoadingEnabled(false);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ResultObject Get(int id)
        {
            if (context.Orders.Contains(id))
            {
                var res = context.Orders.Get(id);
                res.Customer = context.Customers.Get(res.CustomerId);
                //res.OrderItems = context.OrderItems.GetListByOrder(id);
                return new ResultObject(true, res);
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public ResultObject GetAll()
        {
            return new ResultObject(true, context.Orders.GetAll());
        }

        [HttpGet]
        [Route("GetListPaging/{page}/{size}")]
        public ResultObject GetListPaging(int page, int size)
        {
            int total = 1;
            return new ResultObject(true, context.Orders.GetListPaging(out total, page, size), total);
        }

        [HttpGet]
        [Route("GetListByCustomer/{customerId}/{page}/{size}")]
        public ResultObject GetListByCustomer(int customerId, int page, int size)
        {
            int total = 1;
            return new ResultObject(true, context.Orders.GetListByCustomer(customerId, out total, page, size), total);
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
                return new ResultObject(true, context.Orders.GetListByDate(from, to, out total, page, size), total);
            }
            catch (FormatException e)
            {
                return new ResultObject(false, "", e.Message);
            }
        }

        [HttpPost]
        [Route("Insert")]
        public ResultObject Insert([FromBody]Order req)
        {
            return new ResultObject(true, context.Orders.Add(req));
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]Order req)
        {
            if (context.Orders.Contains(req.Id))
            {
                return new ResultObject(true, context.Orders.Update(req));
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ResultObject Delete(int id)
        {
            if (context.Orders.Contains(id))
            {
                return new ResultObject(true, context.Orders.Delete(id));
            }
            return new ResultObject(false, "", "Id not found");
        }
    }
}