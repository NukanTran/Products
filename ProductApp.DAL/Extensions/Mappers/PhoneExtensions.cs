using AutoMapper;
using ProductApp.DAL;
using System.Collections.Generic;

namespace ProductApp
{
    public static class PhoneExtensions
    {
        public static ProductViewModel ToViewModel(this Product_Phone self)
        {
            PhoneViewModel viewModel = Mapper.Map<PhoneViewModel>(self);
            return viewModel;
        }

        public static IEnumerable<PhoneViewModel> ToViewModel(this IEnumerable<Product_Phone> self)
        {
            IEnumerable<PhoneViewModel> viewModel = Mapper.Map<IEnumerable<PhoneViewModel>>(self);
            return viewModel;
        }

        public static Product_Phone ToEntityModel(this PhoneViewModel self)
        {
            Product_Phone entityModel = Mapper.Map<Product_Phone>(self);
            return entityModel;
        }

        public static IEnumerable<Product_Phone> ToEntityModel(this IEnumerable<PhoneViewModel> self)
        {
            IEnumerable<Product_Phone> entityModel = Mapper.Map<IEnumerable<Product_Phone>>(self);
            return entityModel;
        }
    }
}