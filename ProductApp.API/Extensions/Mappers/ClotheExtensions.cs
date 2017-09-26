using AutoMapper;
using ProductApp.API.Models;
using ProductApp.DAL;
using System.Collections.Generic;

namespace ProductApp
{
    public static class ClotheExtensions
    {
        public static ClotheViewModel ToViewModel(this Product_Clothe self)
        {
            ClotheViewModel viewModel = Mapper.Map<ClotheViewModel>(self);
            return viewModel;
        }

        public static IEnumerable<ClotheViewModel> ToViewModel(this IEnumerable<Product_Clothe> self)
        {
            IEnumerable<ClotheViewModel> viewModel = Mapper.Map<IEnumerable<ClotheViewModel>>(self);
            return viewModel;
        }

        public static Product_Clothe ToEntityModel(this ClotheViewModel self)
        {
            Product_Clothe entityModel = Mapper.Map<Product_Clothe>(self);
            return entityModel;
        }

        public static IEnumerable<Product_Clothe> ToEntityModel(this IEnumerable<ClotheViewModel> self)
        {
            IEnumerable<Product_Clothe> entityModel = Mapper.Map<IEnumerable<Product_Clothe>>(self);
            return entityModel;
        }
    }
}