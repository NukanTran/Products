using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ProductApp.DAL;

namespace ProductApp.API
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize( config => {
                config.CreateMap<Product, ProductViewModel>().AfterMap((e,v) => v.SupplierName = e.Supplier == null ? "" : e.Supplier.CompanyName);
                config.CreateMap<Product_Phone, PhoneViewModel>().AfterMap((e, v) => v.SupplierName = e.Supplier == null ? "" : e.Supplier.CompanyName);
                config.CreateMap<Product_Clothe, ClotheViewModel>().AfterMap((e, v) => v.SupplierName = e.Supplier == null ? "" : e.Supplier.CompanyName);
                config.CreateMap<Order, OrderViewModel>().AfterMap((e, v) => v.CustomerName = e.Customer == null ? "" : e.Customer.FirstName ?? "" + " " + e.Customer.LastName ?? "");
                config.CreateMap<OrderItem, OrderItemViewModel>().AfterMap((e, v) => v.ProductName = e.Product == null ? "" : e.Product.ProductName);
                config.CreateMap<Supplier, SupplierViewModel>();
                config.CreateMap<Customer, CustomerViewModel>();

                config.CreateMap<ProductViewModel, Product>();
                config.CreateMap<PhoneViewModel, Product_Phone>();
                config.CreateMap<ClotheViewModel, Product_Clothe> ();
                config.CreateMap<OrderViewModel, Order>();
                config.CreateMap<OrderItemViewModel, OrderItem>();
                config.CreateMap<SupplierViewModel, Supplier>();
                config.CreateMap<CustomerViewModel, Customer>();
            });
        }
    }
}