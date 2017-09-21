using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Products.Models;

namespace Products.DAO
{
    public class ProductDAO
    {

        protected readonly ProductsEntities2 context;

        ProductDAO(ProductsEntities2 context)
        {
            this.context = context;
        }
        
        public List<Product> GetList()
        {
            return context.Products.ToList();
        }
    }
}