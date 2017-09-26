using ProductApp.DAL;
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
            if (context.Clothes.Contains(id))
            {
                return new ResultObject(true, context.Clothes.Get(id).ToViewModel());
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public ResultObject GetAll()
        {
            return new ResultObject(true, context.Clothes.GetAll().ToViewModel(), context.Clothes.Count());
        }

        [HttpGet]
        [Route("GetListPaging/{page}/{size}")]
        public ResultObject GetListPaging(int page, int size)
        {
            int total = 1;
            return new ResultObject(true, context.Clothes.GetListPaging(out total, page, size).ToViewModel(), total);
        }

        [HttpGet]
        [Route("GetListBySupplier/{supplierId}/{page}/{size}")]
        public ResultObject GetListBySupplier(int supplierId, int page, int size)
        {
            if (context.Suppliers.Contains(supplierId))
            {
                int total = 1;
                return new ResultObject(true, context.Clothes.GetListBySupplier(supplierId, out total, page, size).ToViewModel(), total);
            }
            return new ResultObject(false, "", "SupplierId not found");
        }

        [HttpPost]
        [Route("Insert")]
        public ResultObject Insert([FromBody]Product_Clothe req)
        {
            return new ResultObject(true, context.Clothes.Add(req).Id);
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]Product_Clothe req)
        {
            if (context.Clothes.Contains(req.Id))
            {
                return new ResultObject(true, context.Clothes.Update(req));
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ResultObject Delete(int id)
        {
            if (context.Clothes.Contains(id))
            {
                return new ResultObject(true, context.Clothes.Delete(id));
            }
            return new ResultObject(false, "", "Id not found");
        }
    }
}