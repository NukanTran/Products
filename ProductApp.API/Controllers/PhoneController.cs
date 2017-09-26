using ProductApp.DAL;
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
            if (context.Phones.Contains(id))
            {
                return new ResultObject(true, context.Phones.Get(id).ToViewModel());
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public ResultObject GetAll()
        {
            return new ResultObject(true, context.Phones.GetAll().ToViewModel(), context.Phones.Count());
        }

        [HttpGet]
        [Route("GetListPaging/{page}/{size}")]
        public ResultObject GetListPaging(int page, int size)
        {
            int total = 1;
            return new ResultObject(true, context.Phones.GetListPaging(out total, page, size).ToViewModel(), total);
        }

        [HttpGet]
        [Route("GetListBySupplier/{supplierId}/{page}/{size}")]
        public ResultObject GetListBySupplier(int supplierId, int page, int size)
        {
            if (context.Suppliers.Contains(supplierId))
            {
                int total = 1;
                return new ResultObject(true, context.Phones.GetListBySupplier(supplierId, out total, page, size).ToViewModel(), total);
            }
            return new ResultObject(false, "", "SupplierId not found");
        }

        [HttpPost]
        [Route("Insert")]
        public ResultObject Insert([FromBody]Product_Phone req)
        {
            return new ResultObject(true, context.Phones.Add(req).Id);
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]Product_Phone req)
        {
            if (context.Phones.Contains(req.Id))
            {
                return new ResultObject(true, context.Phones.Update(req));
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ResultObject Delete(int id)
        {
            if (context.Phones.Contains(id))
            {
                return new ResultObject(true, context.Phones.Delete(id));
            }
            return new ResultObject(false, "", "Id not found");
        }
    }
}