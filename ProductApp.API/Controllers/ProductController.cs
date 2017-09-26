using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductApp.DAL;

namespace ProductApp.API.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private ProductContext context;
        
        public ProductController()
        {
            context = new ProductContext();
            context.SetLazyLoadingEnabled(false);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ResultObject Get(int id)
        {
            if (context.Products.Contains(id))
            {
                //var res = context.Products.Get(id);
                //res.Supplier = context.Suppliers.Get(res.SupplierId);
                //return new ResultObject(true, res);
                string[] includes = { "Supplier" };
                var res = context.Products.Get(p => p.Id == id, includes);
                return new ResultObject(true, res);
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public ResultObject GetAll()
        {
            return new ResultObject(true, context.Products.GetAll());
        }

        [HttpGet]
        [Route("GetListPaging/{page}/{size}")]
        public ResultObject GetListPaging(int page, int size)
        {
            int total = 1;
            return new ResultObject(true, context.Products.GetListPaging(out total, page, size), total);
        }

        [HttpGet]
        [Route("GetListBySupplier/{supplierId}/{page}/{size}")]
        public ResultObject GetListBySupplier(int supplierId, int page, int size)
        {
            if (context.Suppliers.Contains(supplierId))
            {
                int total = 1;
                return new ResultObject(true, context.Products.GetListBySupplier(supplierId, out total, page, size), total);
            }
            return new ResultObject(false, "", "SupplierId not found");
        }

        [HttpPost]
        [Route("Insert")]
        public ResultObject Insert([FromBody]Product req)
        {
            return new ResultObject(true, context.Products.Add(req));
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]Product req)
        {
            if (context.Products.Contains(req.Id))
            {
                return new ResultObject(true, context.Products.Update(req));
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ResultObject Delete(int id)
        {
            if (context.Products.Contains(id))
            {
                return new ResultObject(true, context.Products.Delete(id));
            }
            return new ResultObject(false, "", "Id not found");
        }

    }
}
