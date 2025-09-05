using AutoMapper;
using DomainLayer;
using DomainLayer.Entities.OrderModels;
using DomainLayer.Entities.ProductsModels;
using DomainLayer.RepositoryAbstraction;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ServiceAbstractionLayer.IServices;
using ServiceImplementationLayer.Exceptions;
using ServiceImplementationLayer.Specificationmplementation;
using SharedDataLayer.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.Service
{
    public class OrderService : IOrderSevice
    {
        private readonly IBasketRepo _basketRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;

        // private readonly IPayment _payment;

        public OrderService(IBasketRepo basketRepo,IMapper mapper, IUnitOfWork unitOfWork,
            IPaymentService paymentService)
        { 
           _basketRepo = basketRepo;
           _mapper = mapper;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
        }
        public async Task<OrderDTO>CreateOrderAsync(string CustomerEmail, CreateOrderDTO createOrderDTO)
        {
            
           var Basket =await _basketRepo.GetBasketAsync(createOrderDTO.BasketId);
            if (Basket == null) throw new BasketNotFoundException(createOrderDTO.BasketId);
            
            var ItemsOrders = new List<ItemOfOrders>();
            
            foreach (var item in Basket.Items)
            {
                var Product = await _unitOfWork.Repository<Product,int>().GetByIdAsync(item.Id);


                var productItemOrder = new ProductItemOrder()
                {
                    ProductId = Product.Id,
                    ProductName = Product.Name,
                    PictureURL = Product.PictureURL,
                };

                var ItemOrder = new ItemOfOrders()
                {
                    productItemOrder = productItemOrder,
                    Price = Product.Price,
                    Quantity = item.Quantity,
                   
                };


                ItemsOrders.Add(ItemOrder);
            }

            var SubTotal= ItemsOrders.Sum(item=>item.Price*item.Quantity);

            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod,int>().GetByIdAsync(createOrderDTO.DeliveryMehodId);

            if (!string.IsNullOrEmpty(Basket.PaymentIntentId))
            {
                var spec = new PaymentSpecification(Basket.PaymentIntentId);
                var ExOrder = await _unitOfWork.Repository<Order,int>().GetByIdAsync(spec);
                await _unitOfWork.Repository<Order, int>().DeleteAsync(ExOrder);
            }

          var BasketDTO = await _paymentService.CreateOrUpdatePaymentAsync(createOrderDTO.BasketId);
               
            var Order = new Order()
            {
                UserEmail = CustomerEmail,

                ShipingAddress = _mapper.Map<Address>(createOrderDTO.ShipingAddress),

                DeliveryMethod = deliveryMethod,

                Items = ItemsOrders,

                SubTotal = SubTotal,

                PayMentIntentId=BasketDTO.PaymentIntentId

            };
            var TotalPrice = Order.TotalPrice();
            if (Order == null)
                return null;
            try
            {
               await _unitOfWork.Repository<Order, int>().AddAsync(Order);

                await _unitOfWork.SaveChange();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var Dataoreder = _mapper.Map<OrderDTO>(Order);
            return Dataoreder;
            
        }

      

        public async Task<List<OrderDTO>?> GetAllOrderAsync(string Email)
        {
          var spec=new OrderSpecification(Email);
           var DataOfOrder=await _unitOfWork.Repository<Order, int>().GetAllAsync(spec);

            if (DataOfOrder == null)
                return null;

            var ConvertOrderToOrderDTO=_mapper.Map<List<OrderDTO>>(DataOfOrder);
            return ConvertOrderToOrderDTO;
        }

        public async Task<OrderDTO?> GetOrderByIdAsync(string Emial, int Id)
        {
            var Spec = new OrderSpecification(Emial, Id);
            var OrderData=await _unitOfWork.Repository<Order, int>().GetByIdAsync(Spec);

            if(OrderData==null) return null;
            var converorderToOrderDTO =_mapper.Map<OrderDTO>(OrderData);
            return converorderToOrderDTO;

        }

        public async Task<List<DeliveryMetodDTO>?> GetAllDeliveryMetodAsync()
        {
           var Data=await _unitOfWork.Repository<DeliveryMethod,int>().GetAllAsync();
            if (Data == null)
                return null;
            var ConvertData=_mapper.Map<List<DeliveryMetodDTO>>(Data);
            return ConvertData; 
        }
    }
}
