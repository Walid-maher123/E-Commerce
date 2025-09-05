using AutoMapper;
using DomainLayer;
using DomainLayer.Entities.OrderModels;
using DomainLayer.RepositoryAbstraction;
using Microsoft.Extensions.Configuration;
using Presistance.Specificationmplementation;
using ServiceAbstractionLayer.IServices;
using ServiceImplementationLayer.Specificationmplementation;
using SharedDataLayer.BasketDTO;
using SharedDataLayer.OrderDTOs;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product = DomainLayer.Entities.ProductsModels.Product;
namespace ServiceImplementationLayer.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IBasketRepo _basketRepo;
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PaymentService(IBasketRepo basketRepo, IUnitOfWork unitofwork,

           IMapper mapper, IConfiguration configuration)
        {
            _basketRepo = basketRepo;
            _unitofwork = unitofwork;

            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<BasketDTO> CreateOrUpdatePaymentAsync(string BasketId)
        {
           
            StripeConfiguration.ApiKey = _configuration["Stripe:Secretkey"];
            var Service = new PaymentIntentService();

            var Basket = await _basketRepo.GetBasketAsync(BasketId);
            if (Basket == null)
                return null;

            var ShipingPrice = 0M;
            if (Basket.DeliveriedMethodId != null)
            {
                var deliveryMethod = await _unitofwork.Repository<DeliveryMethod,int>().GetByIdAsync(Basket.DeliveriedMethodId.Value);
                ShipingPrice = deliveryMethod.Cost;
            }
            if (Basket.Items.Count > 0)
            {
                foreach (var item in Basket.Items)
                {
                  
                        var product = await _unitofwork.Repository<Product,int>().GetByIdAsync(item.Id);
                        if (item.Price != product.Price)
                            item.Price = product.Price;
                    
                    
                }

            }
            var SubTotal = Basket.Items.Sum(o => o.Price * o.Quantity);
            PaymentIntent paymentIntent;
            if (string.IsNullOrEmpty(Basket.PaymentIntentId))
            {
                var PaymentIntentOption = new PaymentIntentCreateOptions()
                {
                    Amount = (long)SubTotal * 100 + (long)ShipingPrice * 100,
                    PaymentMethodTypes = new List<string> { "card" },
                    Currency = "usd"
                };
                paymentIntent = await Service.CreateAsync(PaymentIntentOption);
                Basket.PaymentIntentId = paymentIntent.Id;
                Basket.ClientSecret = paymentIntent.ClientSecret;
            }
            else
            {
                
                var PaymentIntentOption = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)SubTotal * 100 + (long)ShipingPrice * 100,
                };

                paymentIntent = await Service.UpdateAsync(Basket.PaymentIntentId, PaymentIntentOption);
                Basket.PaymentIntentId = paymentIntent.Id;
                Basket.ClientSecret = paymentIntent.ClientSecret;
            }


          var UpdateOrCreateData=  await _basketRepo.CreateOrUpdateAsync(Basket);

            var ConvertBasket = _mapper.Map<BasketDTO>(UpdateOrCreateData);
            return ConvertBasket;



        }

        public async Task<OrderDTO> UpdatePaymentintentSucceedOrFailed(string PaymentintentId, bool Flag)
        {
            var spec = new PaymentSpecification(PaymentintentId);
             var dataOrder = await _unitofwork.Repository<Order,int>().GetByIdAsync(spec);
            if(Flag)
              dataOrder.Status = OrderStatus.PaymentReceived;
            else
                dataOrder.Status = OrderStatus.PaymentFailed;

            await _unitofwork.SaveChange();

            var ConverData =_mapper.Map<OrderDTO>(dataOrder);

            return ConverData;

        }
    }
}
