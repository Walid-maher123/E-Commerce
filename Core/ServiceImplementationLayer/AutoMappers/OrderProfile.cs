using AutoMapper;
using DomainLayer.Entities.OrderModels;
using SharedDataLayer.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.AutoMappers
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<AddressDTO, Address>().ReverseMap();
            CreateMap<OrderStatus,OrderStatusDTO>();
            CreateMap<ProductItemOrder, ProductItemOrderDTO>();

            CreateMap<ItemOfOrders, ItemsOrderDTO>();
            CreateMap<DeliveryMethod, DeliveryMetodDTO>();
            
            
            CreateMap<Order, OrderDTO>().ForMember(ds => ds.DeliveryMethodName
            , s => s.MapFrom(s => s.DeliveryMethod.ShortName)).
               ForMember(ds => ds.Items, s => s.MapFrom(s => s.Items));
          
        }
    }
}
