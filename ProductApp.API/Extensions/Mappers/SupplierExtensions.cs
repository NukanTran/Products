using AutoMapper;
using ProductApp.API.Models;
using ProductApp.DAL;
using System.Collections.Generic;

namespace ProductApp
{
    public static class SupplierExtensions
    {
        public static SupplierViewModel ToViewModel(this Supplier self)
        {
            SupplierViewModel viewModel = Mapper.Map<SupplierViewModel>(self);
            return viewModel;
        }

        public static IEnumerable<SupplierViewModel> ToViewModel(this IEnumerable<Supplier> self)
        {
            IEnumerable<SupplierViewModel> viewModel = Mapper.Map<IEnumerable<SupplierViewModel>>(self);
            return viewModel;
        }

        public static Supplier ToEntityModel(this SupplierViewModel self)
        {
            Supplier entityModel = Mapper.Map<Supplier>(self);
            return entityModel;
        }

        public static IEnumerable<Supplier> ToEntityModel(this IEnumerable<SupplierViewModel> self)
        {
            IEnumerable<Supplier> entityModel = Mapper.Map<IEnumerable<Supplier>>(self);
            return entityModel;
        }
    }
}