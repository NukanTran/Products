using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductApp.Data;
using ProductApp.Data.DAO;
using ProductApp.Data.Infrastructure;

namespace ProductApp.Data
{
    public class ProductContext : IContext
    {
        private DbFactory dbFactory;

        public SupplierDAO Suppliers;
        public CustomerDAO Customers;
        public ProductDAO Products;
        public PhoneDAO Phones;
        public ClotheDAO Clothes;
        public OrderDAO Orders;
        public OrderItemDAO OrderItems;

        public ProductsEntities Context
        {
            get { return dbFactory.Init(); }
        }

        public ProductContext()
        {
            dbFactory = new DbFactory();
            dbFactory.Init();
            Suppliers = new SupplierDAO(dbFactory);
            Customers = new CustomerDAO(dbFactory);
            Products = new ProductDAO(dbFactory);
            Phones = new PhoneDAO(dbFactory);
            Clothes = new ClotheDAO(dbFactory);
            Orders = new OrderDAO(dbFactory);
            OrderItems = new OrderItemDAO(dbFactory);
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void SetLazyLoadingEnabled(bool value)
        {
            Context.Configuration.LazyLoadingEnabled = value;
        }
    }
}