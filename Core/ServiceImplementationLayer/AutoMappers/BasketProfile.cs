using AutoMapper;
using DomainLayer.Entities.BasketModels;
using SharedDataLayer.BasketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.AutoMappers
{
    public  class BasketProfile: Profile
    {
        public BasketProfile()
        {
           CreateMap<BasketDTO,CustomerBasket>().ReverseMap();
           CreateMap<BasketItemDTO,BasketItem>().ReverseMap();
        }
    }
}
