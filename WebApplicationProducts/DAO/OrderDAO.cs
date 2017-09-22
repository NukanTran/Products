using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationProducts.Models;

namespace WebApplicationProducts.DAO
{
    public class OrderDAO
    {
        private ProductsEntities context;

        public OrderDAO(ProductsEntities context)
        {
            this.context = context;
        }

        public int Add(Order order)
        {
            var res = context.Orders.Add(order);
            if (context.SaveChanges() > 0)
            {
                return res.Id;
            }
            return -1;
        }

        public bool Update(Order order)
        {
            var req = context.Orders.FirstOrDefault(o => o.Id == order.Id);
            req.OrderDate = order.OrderDate;
            req.OrderNumber = order.OrderNumber;
            req.CustomerId = order.CustomerId;
            req.TotalAmount = order.TotalAmount;
            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            context.Orders.Remove(context.Orders.FirstOrDefault(o => o.Id == id));
            return context.SaveChanges() > 0;
        }

        public Order Get(int id)
        {
            return context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetAll()
        {
            return context.Orders.OrderBy(o => o.OrderDate).ToList();
        }

        public List<Order> GetListPaging(int page, int count)
        {
            return context.Orders.OrderBy(o => o.OrderDate).Skip(page - 1).Take(count).ToList();
        }

        public bool Exists(int id)
        {
            return context.Orders.Any(s => s.Id == id);
        }

        public List<Order> GetListByDate(int page, int count, DateTime fromDate, DateTime toDate)
        {
            return context.Orders.Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate).OrderBy(v => v.OrderDate).Skip(page - 1).Take(count).ToList();
        }
    }
}