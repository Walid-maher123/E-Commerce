using DomainLayer.Entities.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractionLayer.ITokenAbstraction
{
    public interface IToken
    {
        Task<string> CreateToken(UserApp userApp, UserManager<UserApp> userManager);
    }
}
