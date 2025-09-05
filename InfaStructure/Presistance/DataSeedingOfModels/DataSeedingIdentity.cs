using DomainLayer.Entities.IdentityModels;
using DomainLayer.IDataSeeding;
using Microsoft.AspNetCore.Identity;
using Presistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.DataSeedingOfModels
{
    public class DataSeedingIdentity : IDataSeedingIdentity
    {
        private readonly StoreIdentityDbContext _identityDbContext;
        private readonly UserManager<UserApp> _userManager;

        public DataSeedingIdentity(StoreIdentityDbContext identityDbContext,UserManager<UserApp> userManager)
        {
           _identityDbContext = identityDbContext;
           _userManager = userManager;
        }
        public async Task DataSeedIdentityAsync()
        {
           var GetPend= await _identityDbContext.Database.GetPendingMigrationsAsync();
            if (GetPend.Any())
               await  _identityDbContext.Database.MigrateAsync();

            if(!_identityDbContext.Users.Any())
            {
                var DataUser = new UserApp()
                {
                    DisplayName = "Walid Maher",
                    Email = "walid@gmail.com",
                    UserName = "walidmaher",
                    PhoneNumber="01032245902"
                };

                var Result = await _userManager.CreateAsync(DataUser, "WalidMaher123#");
                if (!Result.Succeeded)
                {
                    foreach(var error in Result.Errors)
                        Console.WriteLine( error);
                }

                
            }
        }
    }
}
