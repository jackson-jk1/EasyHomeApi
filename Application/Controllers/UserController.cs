using Domain.Interfaces;
using Domain.Request.Auth;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Helpers;
using Domain.ViewModels.Request;

namespace Application.Controllers
{
  
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;


        public UserController(IUserService userService, IlogService logService) : base(logService , "UserController")
        {
            _userService = userService;
        }



        // POST: UserController/Create
        [AllowAnonymous]
        [HttpPost("v1/user/")]
     
        public async Task<IActionResult> Register([FromForm] UserRequest user)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
            {

                return FromResult(ModelState);
            }
            return FromResult(await _userService.Register(user));
            
        }

        
        [HttpPut("v1/user/")]
        [Authorize]
        public async Task<IActionResult> Update([FromForm] UserRequest user)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid && user.Image != null)
            {
                return FromResult(ModelState);
            }
            return FromResult(await _userService.Update(HttpContext, user));

        }

        [HttpPut("v1/user/password")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword([FromForm] PasswordRequest pass)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
            {
                return FromResult(ModelState);
            }
            return FromResult(await _userService.UpdatePassword(HttpContext, pass));

        }

        [AllowAnonymous]
        [HttpPut("v1/user/{email}")]

        public async Task<IActionResult> Recover([FromRoute] string email)
        {
           
            return FromResult(await _userService.Recover(email));

        }


        // POST: UserController/Edit/5
        [AllowAnonymous]
        [HttpPost("v1/user/auth")]
 
   
        public async Task<IActionResult> Auth([FromBody] LoginRequest login)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
            {
                return FromResult(ModelState);
            }
            return FromResult(await _userService.Auth(login));

        }
        [Authorize]
        [HttpGet("v1/user/")]
        public async Task<IActionResult> GetUser()
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
            {
                return FromResult(ModelState);
            }
            return FromResult(await _userService.GetByToken(HttpContext));

        }

    }
}
