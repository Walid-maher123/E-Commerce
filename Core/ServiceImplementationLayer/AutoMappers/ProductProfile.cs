using AutoMapper;
using DomainLayer.Entities.ProductsModels;
using SharedDataLayer.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.AutoMappers
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().
               ForMember(ds => ds.BrandName, s => s.MapFrom(s => s.ProductBrand.Name ?? string.Empty))
               .ForMember(ds => ds.TypeName, s => s.MapFrom(s => s.ProductType.Name ?? string.Empty)).
               ForMember(ds => ds.PictureURL, s => s.MapFrom<PictureURLResolver>());
            CreateMap<ProductBrand, BrandDTO>();
            CreateMap<ProductType, TypeDTO>();
        }
    }
}
