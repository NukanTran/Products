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
    [RoutePrefix("api/product/phone")]
    public class PhoneController : ApiController
    {
        private ProductContext context;

        PhoneController()
        {
            context = new ProductContext();
            context.SetLazyLoadingEnabled(false);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public ResultObject Get(int id)
        {
            if (context.Products.Phones.Exists(id))
            {
                var res = context.Products.Phones.Get(id);
                res.Supplier = context.Suppliers.Get(res.SupplierId);
                return new ResultObject(true, res);
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("GetAll")]
        public ResultObject GetAll()
        {
            return new ResultObject(true, context.Products.Phones.GetAll());
        }

        [HttpGet]
        [Route("GetListPaging/{page}/{count}")]
        public ResultObject GetListPaging(int page, int count)
        {
            return new ResultObject(true, context.Products.Phones.GetListPaging(page, count));
        }

        [HttpGet]
        [Route("GetListBySupplier/{page}/{count}/{supplierId}")]
        public ResultObject GetListBySupplier(int page, int count, int supplierId)
        {
            if (context.Suppliers.Exists(supplierId))
            {
                return new ResultObject(true, context.Products.Phones.GetListBySupplier(page, count, supplierId));
            }
            return new ResultObject(false, "", "SupplierId not found");
        }

        [HttpPost]
        [Route("Insert")]
        public ResultObject Insert([FromBody]Product_Phone req)
        {
            return new ResultObject(true, context.Products.Add(req));
        }

        [HttpPost]
        [Route("Update")]
        public ResultObject Update([FromBody]Product_Phone req)
        {
            if (context.Products.Phones.Exists(req.Id))
            {
                return new ResultObject(true, context.Products.Phones.Update(req));
            }
            return new ResultObject(false, "", "Id not found");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ResultObject Delete(int id)
        {
            if (context.Products.Phones.Exists(id))
            {
                return new ResultObject(true, context.Products.Delete(id));
            }
            return new ResultObject(false, "", "Id not found");
        }
    }
}
