using AutoMapper;
using DomainLayer.Entities.ProductsModels;
using Microsoft.Extensions.Configuration;
using SharedDataLayer.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.AutoMappers
{
    internal class PictureURLResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;

        public PictureURLResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if(string.IsNullOrEmpty(source.PictureURL))
                return string.Empty;
            return $"{_configuration["Url:BaseUrl"]}{source.PictureURL}";
        }
    }
}
