using DomainLayer.IDataSeedingOfModels;
using DomainLayer.RepositoryAbstraction;
using DomainLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presistance.RepositoryImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presistance.Contexts;
using ServiceAbstractionLayer.ITokenAbstraction;
using Presistance.TokenImplementation;
using DomainLayer.Entities.IdentityModels;
using Microsoft.AspNetCore.Identity;
using DomainLayer.IDataSeeding;
using Presistance.DataSeedingOfModels;
using Presistance.DataSeedingOfModels.DataSeeding;


namespace Presistance
{
    public static class PresistanceService
    {
        public static IServiceCollection PresistanceServiceRegister(this IServiceCollection Services,IConfiguration Configuration)
        {
            Services.AddScoped(typeof(IGenericRepo<,>), typeof(GenericRepo<,>));
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IBasketRepo, BasketRepo>();
            Services.AddScoped<IToken, Token>();
            Services.AddScoped<IDataSeedingIdentity, DataSeedingIdentity>();
           Services.AddScoped<IDataSeeding, DataSeeding>();

            Services.AddDbContext<StoreIdentityDbContext>(
             op => op.UseSqlServer(Configuration.GetConnectionString("StoreIdentity")),
             ServiceLifetime.Scoped

             );
            Services.AddDbContext<StoreDbContext>(
               op => op.UseSqlServer(Configuration.GetConnectionString("E-CommerceConnection"))

               );

            return Services;


        }
    }
}
