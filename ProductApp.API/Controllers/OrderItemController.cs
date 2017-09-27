using ProductApp.DAL;
using System;
using System.Web.Http;

namespace ProductApp.API.Controllers
{
    public interface IOrderItemController : IApiController<OrderItem>
    {
        ResultObject GetListByOrder(int orderId, int page, int size);
    }

    [RoutePrefix("api/order/item")]
    public class OrderItemController : ApiController, IOrderItemController
    {
        private ProductContext context;

        private OrderItemController()
        {
            context = new ProductContext();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ResultObject Get(int id)
        {
            try
            {
                if (context.OrderItems.Contains(id))
                {
                    return new ResultObject(true, context.OrderItems.Get(id).ToViewModel());
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
                return new ResultObject(true, context.OrderItems.GetAll().ToViewModel(), context.OrderItems.Count());
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
                return new ResultObject(true, context.OrderItems.GetListPaging(out total, page, size).ToViewModel(), total);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpGet]
        [Route("GetListByOrder/{customerId}/{page}/{size}")]
        public ResultObject GetListByOrder(int orderId, int page, int size)
        {
            try
            {
                int total = 1;
                return new ResultObject(true, context.OrderItems.GetListByOrder(orderId, out total, page, size).ToViewModel(), total);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpPost]
        [Route("Insert")]
        public ResultObject Insert([FromBody]OrderItem req)
        {
            try
            {
                return new ResultObject(true, context.OrderItems.Add(req).Id);
            }
            catch (Exception e)
            {
                return new ResultObject(false, null, e.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]OrderItem req)
        {
            try
            {
                if (context.OrderItems.Contains(req.Id))
                {
                    return new ResultObject(true, context.OrderItems.Update(req));
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
                if (context.OrderItems.Contains(id))
                {
                    return new ResultObject(true, context.OrderItems.Delete(id));
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