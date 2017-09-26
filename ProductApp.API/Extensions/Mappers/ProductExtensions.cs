using AutoMapper;
using ProductApp.API.Models;
using ProductApp.DAL;
using System.Collections.Generic;

namespace ProductApp
{
    public static class ProductExtensions
    {
        public static ProductViewModel ToViewModel(this Product self)
        {
            ProductViewModel viewModel = Mapper.Map<ProductViewModel>(self);
            return viewModel;
        }

        public static IEnumerable<ProductViewModel> ToViewModel(this IEnumerable<Product> self)
        {
            IEnumerable<ProductViewModel> viewModel = Mapper.Map<IEnumerable<ProductViewModel>>(self);
            return viewModel;
        }

        public static Product ToEntityModel(this ProductViewModel self)
        {
            Product entityModel = Mapper.Map<Product>(self);
            return entityModel;
        }

        public static IEnumerable<Product> ToEntityModel(this IEnumerable<ProductViewModel> self)
        {
            IEnumerable<Product> entityModel = Mapper.Map<IEnumerable<Product>>(self);
            return entityModel;
        }
    }
}