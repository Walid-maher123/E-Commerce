using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceAbstractionLayer.IServices;
using ServiceImplementationLayer.AutoMappers;
using ServiceImplementationLayer.Service;
using StackExchange.Redis;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductService = ServiceImplementationLayer.Service.ProductService;

namespace ServiceImplementationLayer
{
    public static class ApplicationService
    {
        public static IServiceCollection ApplicationServiceRegister(this IServiceCollection Services,IConfiguration Configuration)
        {
            Services.AddAutoMapper(typeof(ProductProfile).Assembly);
            Services.AddAutoMapper(typeof(BasketProfile).Assembly);
            Services.AddAutoMapper(typeof(OrderProfile).Assembly);
            Services.AddScoped<IProductService, ProductService>();
            Services.AddScoped<IOrderSevice, OrderService>();
            Services.AddScoped<IBasketService, BasketService>();
            Services.AddScoped<IPaymentService, PaymentService>();
            Services.AddSingleton<IResponseCachService,ResponseCachService>();
            Services.AddScoped<IAuthService, AuthService>();

            Services.AddSingleton<IConnectionMultiplexer>((_) =>

                 ConnectionMultiplexer.Connect(Configuration.GetConnectionString("Redis")
            ));

            return Services;

        }
    }
}
