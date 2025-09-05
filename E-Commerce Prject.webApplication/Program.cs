


namespace E_Commerce_Prject.webApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


            builder.Services.ApplicationServiceRegister(builder.Configuration);
            builder.Services.PresistanceServiceRegister(builder.Configuration);
            builder.Services.WebServiceRegister();
          

            builder.Services.AddIdentity<UserApp, IdentityRole>().AddEntityFrameworkStores<StoreIdentityDbContext>();
       


          

            builder.Services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
             ).AddJwtBearer(op =>
             {
                 op.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidIssuer = builder.Configuration["Jwt:Issuer"],
                     ValidateAudience = true,
                     ValidAudience = builder.Configuration["Jwt:Audience"],
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                 };
             });


            var app = builder.Build();

         
            await app.SeedDataAsync();
      
            app.CustomMiddleWare();
            if (app.Environment.IsDevelopment())
            {
                
                app.SwaggerService();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
