using DomainLayer.Entities.IdentityModels;
using ServiceAbstractionLayer.ITokenAbstraction;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;


namespace Presistance.TokenImplementation
{
    public class Token : IToken
    {
        private readonly IConfiguration _configuration;

        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateToken(UserApp userApp,UserManager<UserApp> userManager)
        {
            var AuthClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, userApp.Email),
                new Claim(ClaimTypes.MobilePhone,userApp.PhoneNumber),
                new Claim(ClaimTypes.GivenName,userApp.DisplayName)
            };
            var securtykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var Roles = await userManager.GetRolesAsync(userApp);
            foreach (var item in Roles)
                AuthClaim.Add(new Claim(ClaimTypes.Role, item));
            var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["Jwt:DurationTime"])),
                claims: AuthClaim,
                signingCredentials:new SigningCredentials(securtykey,SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
