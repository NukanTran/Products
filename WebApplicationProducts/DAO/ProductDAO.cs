using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationProducts.Models;

namespace WebApplicationProducts.DAO
{
    public class ProductDAO
    {

        private ProductsEntities context;

        public Product_PhoneDAO Phones;
        public Product_ClotheDAO Clothes;

        public ProductDAO(ProductsEntities context)
        {
            this.context = context;
            this.Phones = new Product_PhoneDAO(context);
            this.Clothes = new Product_ClotheDAO(context);
        }

        public int Add(Product product)
        {
            var res = context.Products.Add(product);
            if (context.SaveChanges() > 0)
            {
                return res.Id;
            }
            return -1;
        }

        public bool Update(Product product)
        {
            var req = context.Products.FirstOrDefault(p => p.Id == product.Id);
            req.ProductName = product.ProductName;
            req.SupplierId = product.SupplierId;
            req.UnitPrice = product.UnitPrice;
            req.Package = product.Package;
            req.IsDiscontinued = product.IsDiscontinued;
            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            context.Products.Remove(context.Products.FirstOrDefault(p => p.Id == id));
            return context.SaveChanges() > 0;
        }

        public Product Get(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAll()
        {
            return context.Products.OrderBy(p => p.ProductName).ToList();
        }

        public List<Product> GetListPaging(int page, int count)
        {
            return context.Products.OrderBy(p => p.ProductName).Skip(page - 1).Take(count).ToList();
        }

        public List<Product> GetListBySupplier(int page, int count, int supplierId)
        {
            return context.Products.Where(p => p.SupplierId == supplierId).OrderBy(p => p.ProductName).Skip(page - 1).Take(count).ToList();
        }

        public bool Exists(int id)
        {
            return context.Products.Any(p => p.Id == id);
        }
    }
}