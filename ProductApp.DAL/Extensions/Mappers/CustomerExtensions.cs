using AutoMapper;
using ProductApp.DAL;
using System.Collections.Generic;

namespace ProductApp
{
    public static class CustomerExtensions
    {
        public static CustomerViewModel ToViewModel(this Customer self)
        {
            CustomerViewModel viewModel = Mapper.Map<CustomerViewModel>(self);
            return viewModel;
        }

        public static IEnumerable<CustomerViewModel> ToViewModel(this IEnumerable<Customer> self)
        {
            IEnumerable<CustomerViewModel> viewModel = Mapper.Map<IEnumerable<CustomerViewModel>>(self);
            return viewModel;
        }

        public static Customer ToEntityModel(this CustomerViewModel self)
        {
            Customer entityModel = Mapper.Map<Customer>(self);
            return entityModel;
        }

        public static IEnumerable<Customer> ToEntityModel(this IEnumerable<CustomerViewModel> self)
        {
            IEnumerable<Customer> entityModel = Mapper.Map<IEnumerable<Customer>>(self);
            return entityModel;
        }
    }
}