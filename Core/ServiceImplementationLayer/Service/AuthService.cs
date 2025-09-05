using DomainLayer.Entities.IdentityModels;
using Microsoft.AspNetCore.Identity;
using ServiceAbstractionLayer.IServices;
using ServiceAbstractionLayer.ITokenAbstraction;
using SharedDataLayer.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementationLayer.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManage;
        private readonly IToken _token;

        public AuthService(UserManager<UserApp> userManager,SignInManager<UserApp> signInManage,IToken token)
        {
            _userManager = userManager;
            _signInManage = signInManage;
            _token = token;
        }
        public async  Task<UserDTO> SignIn(LoginDTO login)
        {
            var dataUse=await _userManager.FindByEmailAsync(login.Email);
            if (dataUse == null)
            {
                return new UserDTO()
                {
                    Message = " The Email Not Found Please first Register",
                    IsAutheried = false,
                    Token="Invalid"
                };
             }

            var result = await _signInManage.CheckPasswordSignInAsync(dataUse,login.Password,false);
            if (result.Succeeded)
            {
                return new UserDTO()
                {
                    Message = " The Correct login ",
                    IsAutheried = true,
                    Token = await _token.CreateToken(dataUse, _userManager)
                };
            }
            return new UserDTO()
            {
                Message = "Not Login ",

            };
        }


        public async Task<UserDTO> SignUp(RegisterDTO registerDTO)
        {
            var DataOfUser = await _userManager.FindByEmailAsync(registerDTO.Email);
            if (DataOfUser != null) return new UserDTO()
            {
                Message = "The Email Is Found "
            };
            var UserApp = new UserApp()
            {
                DisplayName = registerDTO.DisplayName,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumeber,
                UserName=registerDTO.UserName
            };

            var Result = await _userManager.CreateAsync(UserApp, registerDTO.Password);
            if (Result.Succeeded)
            {
                return new UserDTO()
                {
                    Message = " The User Is Created",
                    IsAutheried = true,
                    Token = await _token.CreateToken(UserApp, _userManager)
                };

            }
            else
            {
                foreach(var e in Result.Errors)
                    Console.WriteLine( e.Description);
            }
                return new UserDTO()
                {
                    Message = "Error CreatedUSer"
                };
        }

        public async Task<CurrentUserDTO?> ValidateGetCurrentUser(string? Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (user == null)
                return null;

            return new CurrentUserDTO()
            {
                DisplayName = user.DisplayName,

                Email = user.Email,

                Token = await _token.CreateToken(user, _userManager)

            };
        }
    }
}
