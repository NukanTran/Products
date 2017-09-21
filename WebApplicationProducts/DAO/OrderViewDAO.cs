using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationProducts.Models;

namespace WebApplicationProducts.DAO
{
    public class OrderViewDAO
    {
        private ProductsEntities context;

        public OrderViewDAO(ProductsEntities context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            context.OrderItems.Remove(context.OrderItems.FirstOrDefault(o => o.Id == id));
            return context.SaveChanges() > 0;
        }

        public OrderView Get(int id)
        {
            return context.OrderViews.FirstOrDefault(v => v.ItemId == id);
        }

        public List<OrderView> GetAll()
        {
            return context.OrderViews.OrderBy(v => v.OrderDate).ToList();
        }

        public List<OrderView> GetListPaging(int page, int count)
        {
            return context.OrderViews.OrderBy(v => v.OrderDate).Skip(page - 1).Take(count).ToList();
        }

        public List<OrderView> GetListByCustomer(int page, int count, int customerId)
        {
            return context.OrderViews.Where(v => v.CustomerId == customerId).OrderBy(v => v.OrderDate).Skip(page - 1).Take(count).ToList();
        }

        public List<OrderView> GetListByProduct(int page, int count, int productId)
        {
            return context.OrderViews.Where(v => v.ProductId == productId).OrderBy(v => v.OrderDate).Skip(page - 1).Take(count).ToList();
        }

        public List<OrderView> GetListByDate(int page, int count, DateTime fromDate, DateTime toDate)
        {
            return context.OrderViews.Where(v => v.OrderDate >= fromDate && v.OrderDate <= toDate).OrderBy(v => v.OrderDate).Skip(page - 1).Take(count).ToList();
        }
    }
}