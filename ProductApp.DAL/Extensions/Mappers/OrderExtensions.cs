using AutoMapper;
using ProductApp.DAL;
using System.Collections.Generic;

namespace ProductApp
{
    public static class OrderExtensions
    {
        public static OrderViewModel ToViewModel(this Order self)
        {
            OrderViewModel viewModel = Mapper.Map<OrderViewModel>(self);
            return viewModel;
        }

        public static IEnumerable<OrderViewModel> ToViewModel(this IEnumerable<Order> self)
        {
            IEnumerable<OrderViewModel> viewModel = Mapper.Map<IEnumerable<OrderViewModel>>(self);
            return viewModel;
        }

        public static Order ToEntityModel(this OrderViewModel self)
        {
            Order entityModel = Mapper.Map<Order>(self);
            return entityModel;
        }

        public static IEnumerable<Order> ToEntityModel(this IEnumerable<OrderViewModel> self)
        {
            IEnumerable<Order> entityModel = Mapper.Map<IEnumerable<Order>>(self);
            return entityModel;
        }
    }
}