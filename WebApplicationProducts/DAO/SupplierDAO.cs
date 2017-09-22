using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationProducts.Models;

namespace WebApplicationProducts.DAO
{
    public class SupplierDAO
    {
        private ProductsEntities context;

        public SupplierDAO(ProductsEntities context)
        {
            this.context = context;
        }

        public int Add(Supplier supplier)
        {
            var res = context.Suppliers.Add(supplier);
            if(context.SaveChanges() > 0)
            {
                return res.Id;
            }
            return -1;
        }

        public bool Update(Supplier supplier)
        {
            var req = context.Suppliers.FirstOrDefault(s => s.Id == supplier.Id);
            req.CompanyName = supplier.CompanyName;
            req.ContactName = supplier.ContactName;
            req.ContactTitle = supplier.ContactTitle;
            req.City = supplier.City;
            req.Country = supplier.Country;
            req.Phone = supplier.Phone;
            req.Fax = supplier.Fax;
            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            context.Suppliers.Remove(context.Suppliers.FirstOrDefault(s => s.Id == id));
            return context.SaveChanges() > 0;
        }

        public Supplier Get(int id)
        {
            return context.Suppliers.FirstOrDefault(s => s.Id == id);
        }

        public List<Supplier> GetAll()
        {
            return context.Suppliers.OrderBy(s => s.CompanyName).ToList();
        }

        public List<Supplier> GetListPaging(int page, int count)
        {
            return context.Suppliers.OrderBy(s => s.CompanyName).Skip(page - 1).Take(count).ToList();
        }

        public List<Supplier> GetListByCountry(int page, int count, string country)
        {
            return context.Suppliers.Where(s => s.Country == country).OrderBy(s => s.CompanyName).Skip(page - 1).Take(count).ToList();
        }

        public bool Exists(int id)
        {
            return context.Suppliers.Any(s => s.Id == id);
        }
    }
}