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
            if (context.Products.Exists(id))
            {
                var res = context.Products.Get(id);
                res.Supplier = context.Suppliers.Get(res.SupplierId);
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
        [Route("GetListPaging/{page}/{count}")]
        public ResultObject GetListPaging(int page, int count)
        {
            return new ResultObject(true, context.Products.GetListPaging(page, count));
        }

        [HttpGet]
        [Route("GetListBySupplier/{page}/{count}/{supplierId}")]
        public ResultObject GetListBySupplier(int page, int count, int supplierId)
        {
            if (context.Suppliers.Exists(supplierId))
            {
                return new ResultObject(true, context.Products.GetListBySupplier(page, count, supplierId));
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
            if (context.Products.Exists(req.Id))
            {
                return new ResultObject(true, context.Products.Update(req));
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ResultObject Delete(int id)
        {
            if (context.Products.Exists(id))
            {
                return new ResultObject(true, context.Products.Delete(id));
            }
            return new ResultObject(false, "", "Id not found");
        }

    }
}
