using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer.IServices;
using SharedDataLayer.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController: ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<ActionResult> SignUpAsync(RegisterDTO registerDTO)
        {
           var RegisterData =await  _authService.SignUp(registerDTO);
            return Ok(RegisterData);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> SignInAsync(LoginDTO loginDTO)
        {
            var loginData = await _authService.SignIn(loginDTO);
            return Ok(loginData);
        }

        [HttpGet("GetCurrentUser")]
        [Authorize]
        public async Task<ActionResult> GetCurrentUser()
        {
            var useremail = User.FindFirstValue(ClaimTypes.Email);
            var user = await _authService.ValidateGetCurrentUser(useremail);
            return Ok(user);

        }
    }
}
