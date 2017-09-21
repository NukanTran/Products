using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationProducts.Models;

namespace WebApplicationProducts.DAO
{
    public class OrderItemDAO
    {
        private ProductsEntities context;

        public OrderItemDAO(ProductsEntities context)
        {
            this.context = context;
        }

        public int Add(OrderItem orderItem)
        {
            var res = context.OrderItems.Add(orderItem);
            if (context.SaveChanges() > 0)
            {
                return res.Id;
            }
            return -1;
        }

        public List<int> Add(List<OrderItem> listOrderItem)
        {
            List<int> res = new List<int>();
            var listRes = context.OrderItems.AddRange(listOrderItem).ToList();
            if (context.SaveChanges() > 0)
            {
                foreach (var i in listOrderItem)
                {
                    res.Add(i.Id);
                }
            }
            return res;
        }

        public bool Update(OrderItem orderItem)
        {
            var req = context.OrderItems.FirstOrDefault(o => o.Id == orderItem.Id);
            req.OrderId = orderItem.OrderId;
            req.ProductId = orderItem.ProductId;
            req.UnitPrice = orderItem.UnitPrice;
            req.Quantity = orderItem.Quantity;
            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            context.OrderItems.Remove(context.OrderItems.FirstOrDefault(o => o.Id == id));
            return context.SaveChanges() > 0;
        }

        public OrderItem Get(int id)
        {
            return context.OrderItems.FirstOrDefault(o => o.Id == id);
        }

        public List<OrderItem> GetAll()
        {
            return context.OrderItems.OrderBy(o => o.Order.OrderDate).ToList();
        }

        public List<OrderItem> GetListPaging(int page, int count)
        {
            return context.OrderItems.OrderBy(o => o.Order.OrderDate).Skip(page - 1).Take(count).ToList();
        }

        public List<OrderItem> GetListByOrder(int orderId)
        {
            return context.OrderItems.OrderBy(o => o.OrderId == orderId).ToList();
        }
    }
}