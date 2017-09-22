using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationProducts.Models;

namespace WebApplicationProducts.DAO
{
    public class Product_ClotheDAO
    {
        private ProductsEntities context;

        public Product_ClotheDAO(ProductsEntities context)
        {
            this.context = context;
        }

        public bool Update(Product_Clothe product)
        {
            var req = context.Products.OfType<Product_Clothe>().FirstOrDefault(p => p.Id == product.Id);
            req.ProductName = product.ProductName;
            req.SupplierId = product.SupplierId;
            req.UnitPrice = product.UnitPrice;
            req.Package = product.Package;
            req.IsDiscontinued = product.IsDiscontinued;
            req.Color = product.Color;
            req.Size = product.Size;
            req.Material = product.Material;
            return context.SaveChanges() > 0;
        }

        public Product_Clothe Get(int id)
        {
            return context.Products.OfType<Product_Clothe>().FirstOrDefault(p => p.Id == id);
        }

        public List<Product_Clothe> GetAll()
        {
            return context.Products.OfType<Product_Clothe>().OrderBy(p => p.ProductName).ToList();
        }

        public List<Product_Clothe> GetListPaging(int page, int count)
        {
            return context.Products.OfType<Product_Clothe>().OrderBy(p => p.ProductName).Skip(page - 1).Take(count).ToList();
        }

        public List<Product_Clothe> GetListBySupplier(int page, int count, int supplierId)
        {
            return context.Products.OfType<Product_Clothe>().Where(p => p.SupplierId == supplierId).OrderBy(p => p.ProductName).Skip(page - 1).Take(count).ToList();
        }

        public bool Exists(int id)
        {
            return context.Products.OfType<Product_Clothe>().Any(p => p.Id == id);
        }
    }
}