using DomainLayer.IDataSeeding;
using DomainLayer.IDataSeedingOfModels;

namespace E_Commerce_Prject.webApplication
{
   public static class WebService
    {
     
        public static IServiceCollection WebServiceRegister(this IServiceCollection Services)
        {

            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            return Services;
        }

        public static async Task SeedDataAsync(this WebApplication app)
        {
            using var Scoope = app.Services.CreateScope();
            var ObjectData = Scoope.ServiceProvider.GetRequiredService<IDataSeeding>();
            var DataSeedidentity = Scoope.ServiceProvider.GetRequiredService<IDataSeedingIdentity>();
            try
            {
                await ObjectData.DataSeedAsync();
                await DataSeedidentity.DataSeedIdentityAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

         public static IApplicationBuilder SwaggerService(this IApplicationBuilder app) 
         {
                app.UseSwagger();
                app.UseSwaggerUI();
                return app;
         }

        public static IApplicationBuilder CustomMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptions>();
            return app;
        }
    }
  
}
