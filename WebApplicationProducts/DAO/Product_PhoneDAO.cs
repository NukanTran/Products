using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationProducts.Models;

namespace WebApplicationProducts.DAO
{
    public class Product_PhoneDAO
    {
        private ProductsEntities context;

        public Product_PhoneDAO(ProductsEntities context)
        {
            this.context = context;
        }

        public bool Update(Product_Phone product)
        {
            var req = context.Products.OfType<Product_Phone>().FirstOrDefault(p => p.Id == product.Id);
            req.ProductName = product.ProductName;
            req.SupplierId = product.SupplierId;
            req.UnitPrice = product.UnitPrice;
            req.Package = product.Package;
            req.IsDiscontinued = product.IsDiscontinued;
            req.Color = product.Color;
            req.Size = product.Size;
            req.Ram = product.Ram;
            req.Weight = product.Weight;
            req.Chipset = product.Chipset;
            req.Storage = product.Storage;
            return context.SaveChanges() > 0;
        }

        public Product_Phone Get(int id)
        {
            return context.Products.OfType<Product_Phone>().FirstOrDefault(p => p.Id == id);
        }

        public List<Product_Phone> GetAll()
        {
            return context.Products.OfType<Product_Phone>().OrderBy(p => p.ProductName).ToList();
        }

        public List<Product_Phone> GetListPaging(int page, int count)
        {
            return context.Products.OfType<Product_Phone>().OrderBy(p => p.ProductName).Skip(page - 1).Take(count).ToList();
        }

        public List<Product_Phone> GetListBySupplier(int page, int count, int supplierId)
        {
            return context.Products.OfType<Product_Phone>().Where(p => p.SupplierId == supplierId).OrderBy(p => p.ProductName).Skip(page - 1).Take(count).ToList();
        }

        public bool Exists(int id)
        {
            return context.Products.OfType<Product_Phone>().Any(p => p.Id == id);
        }
    }
}
