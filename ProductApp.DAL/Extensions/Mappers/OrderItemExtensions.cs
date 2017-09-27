using AutoMapper;
using ProductApp.DAL;
using System.Collections.Generic;

namespace ProductApp
{
    public static class OrderItemExtensions
    {
        public static OrderItemViewModel ToViewModel(this OrderItem self)
        {
            OrderItemViewModel viewModel = Mapper.Map<OrderItemViewModel>(self);
            return viewModel;
        }

        public static IEnumerable<OrderItemViewModel> ToViewModel(this IEnumerable<OrderItem> self)
        {
            IEnumerable<OrderItemViewModel> viewModel = Mapper.Map<IEnumerable<OrderItemViewModel>>(self);
            return viewModel;
        }

        public static OrderItem ToEntityModel(this OrderItemViewModel self)
        {
            OrderItem entityModel = Mapper.Map<OrderItem>(self);
            return entityModel;
        }

        public static IEnumerable<OrderItem> ToEntityModel(this IEnumerable<OrderItemViewModel> self)
        {
            IEnumerable<OrderItem> entityModel = Mapper.Map<IEnumerable<OrderItem>>(self);
            return entityModel;
        }
    }
}