using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationProducts.Models;
using WebApplicationProducts.DAO;

namespace WebApplicationProducts.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private ProductContext context;

        OrderController()
        {
            context = new ProductContext();
            context.SetLazyLoadingEnabled(false);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ResultObject Get(int id)
        {
            if (context.Orders.Exists(id))
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
        [Route("GetListPaging/{page}/{count}")]
        public ResultObject GetListPaging(int page, int count)
        {
            return new ResultObject(true, context.Orders.GetListPaging(page, count));
        }

        [HttpGet]
        [Route("GetListByDate/{page}/{count}/{fromDate}/{toDate}")]
        public ResultObject GetListByDate(int page, int count, string fromDate, string toDate)
        {
            try
            {
                var format = "dd-MM-yyyy";
                var from = DateTime.ParseExact(fromDate, format, null);
                var to = DateTime.ParseExact(toDate, format, null);
                return new ResultObject(true, context.Orders.GetListByDate(page, count, from, to));
            }
            catch(FormatException e)
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
            if (context.Orders.Exists(req.Id))
            {
                return new ResultObject(true, context.Orders.Update(req));
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ResultObject Delete(int id)
        {
            if (context.Orders.Exists(id))
            {
                return new ResultObject(true, context.Orders.Delete(id));
            }
            return new ResultObject(false, "", "Id not found");
        }
    }
}
