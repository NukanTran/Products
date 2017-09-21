using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationProducts.Models;

namespace WebApplicationProducts.DAO
{
    public class ProductContext
    {

        private ProductsEntities context;

        public ProductDAO Products;
        public SupplierDAO Suppliers;
        public CustomerDAO Customers;
        public OrderDAO Orders;
        public OrderItemDAO OrderItems;
        public OrderViewDAO OrderViews;

        public ProductContext()
        {
            context = new ProductsEntities();
            Products = new ProductDAO(context);
            Suppliers = new SupplierDAO(context);
            Customers = new CustomerDAO(context);
            Orders = new OrderDAO(context);
            OrderItems = new OrderItemDAO(context);
            OrderViews = new OrderViewDAO(context);
        }

        public void SetLazyLoadingEnabled(bool value)
        {
            context.Configuration.LazyLoadingEnabled = value;
        }
    }
}