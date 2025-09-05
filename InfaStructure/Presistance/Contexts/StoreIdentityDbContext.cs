using DomainLayer.Entities.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Contexts
{
    public class StoreIdentityDbContext: IdentityDbContext<UserApp>
    {
        public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options):base(options) 
        {
            
        }

    }
}
