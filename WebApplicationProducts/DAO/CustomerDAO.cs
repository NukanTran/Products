using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationProducts.Models;

namespace WebApplicationProducts.DAO
{
    public class CustomerDAO
    {
        private ProductsEntities context;

        public CustomerDAO(ProductsEntities context)
        {
            this.context = context;
        }

        public int Add(Customer customer)
        {
            var res = context.Customers.Add(customer);
            if (context.SaveChanges() > 0)
            {
                return res.Id;
            }
            return -1;
        }

        public bool Update(Customer customer)
        {
            var req = context.Customers.FirstOrDefault(c => c.Id == customer.Id);
            req.FirstName = customer.FirstName;
            req.LastName = customer.LastName;
            req.City = customer.City;
            req.Country = customer.Country;
            req.Phone = customer.Phone;
            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            context.Customers.Remove(context.Customers.FirstOrDefault(c => c.Id == id));
            return context.SaveChanges() > 0;
        }

        public Customer Get(int id)
        {
            return context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public List<Customer> GetAll()
        {
            return context.Customers.OrderBy(c => c.FirstName + c.LastName).ToList();
        }

        public List<Customer> GetListPaging(int page, int count)
        {
            return context.Customers.OrderBy(c => c.FirstName + c.LastName).Skip(page - 1).Take(count).ToList();
        }

        public List<Customer> GetListByCountry(int page, int count, string country)
        {
            return context.Customers.Where(c => c.Country == country).OrderBy(c => c.FirstName + c.LastName).Skip(page - 1).Take(count).ToList();
        }
        
    }
}