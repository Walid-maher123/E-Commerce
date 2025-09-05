using SharedDataLayer.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractionLayer.IServices
{
    public interface IAuthService
    {
        Task<UserDTO> SignUp(RegisterDTO registerDTO);

        Task<UserDTO> SignIn(LoginDTO registerDTO);

        public Task<CurrentUserDTO?> ValidateGetCurrentUser(string? Email);

    }
}
