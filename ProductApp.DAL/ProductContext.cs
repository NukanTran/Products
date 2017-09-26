using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductApp.DAL.DAO;
using ProductApp.DAL.Infrastructure;

namespace ProductApp.DAL
{
    public class ProductContext
    {
        private DbFactory dbFactory;

        public SupplierDAO Suppliers;
        public CustomerDAO Customers;
        public ProductDAO<Product> Products;
        public PhoneDAO Phones;
        public ClotheDAO Clothes;
        public OrderDAO Orders;
        public OrderItemDAO OrderItems;

        private ProductsEntities Context
        {
            get { return dbFactory.Init(); }
        }

        public ProductContext()
        {
            dbFactory = new DbFactory();
            dbFactory.Init();
            Suppliers = new SupplierDAO(dbFactory);
            Customers = new CustomerDAO(dbFactory);
            Products = new ProductDAO<Product>(dbFactory);
            Phones = new PhoneDAO(dbFactory);
            Clothes = new ClotheDAO(dbFactory);
            Orders = new OrderDAO(dbFactory);
            OrderItems = new OrderItemDAO(dbFactory);
        }

        public void SetLazyLoadingEnabled(bool value)
        {
            Context.Configuration.LazyLoadingEnabled = value;
        }
    }
}