using Domain.Interfaces;
using Domain.Request.Auth;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Helpers;
using Domain.ViewModels.Request;
using Service.Services;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> UpdatePassword([FromBody] PasswordRequest pass)
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
            return FromResult(await _userService.GetByToken(HttpContext));

        }

        [Authorize]
        [HttpGet("v1/user/preference/{id}")]
        public async Task<IActionResult> GetImmobiles(int id)
        {
            _stopwatch.Start();
            var data = await _userService.checkImmobile(HttpContext, id);
            return Json(new { data = data.Data });

        }

        [Authorize]
        [HttpPost("v1/user/addPreference/{id}")]
        public async Task<IActionResult> addPreference(int id)
        {
            _stopwatch.Start();
            var data = await _userService.addFavorite(HttpContext, id);
            return Json(new { data = data.Data });

        }

        [Authorize]
        [HttpDelete("v1/user/removePreference/{id}")]
        public async Task<IActionResult> removePreference(int id)
        {
            _stopwatch.Start();
            var data = await _userService.removeFavorite(HttpContext, id);
            return Json(new { data = data.Data });

        }
        
        [Authorize]
        [HttpGet("v1/user/getByImm/{id}")]
        public async Task<IActionResult> getUsersByImmobile(int id)
        {
            _stopwatch.Start();
            var data = await _userService.getUsersByImmobile(HttpContext, id);
            return Json(new { data = data.Data });

        }

  
        [Authorize]
        [HttpPut("v1/user/addNotification/")]
        public async Task<IActionResult> addNotification([FromBody] NotificationRequest not)
        {
            _stopwatch.Start();
            var data = await _userService.addNotification(HttpContext, not);
            return Json(new { data = data.Data });

        }

        [Authorize]
        [HttpPut("v1/user/readNotification/")]
        public void readNotification()
        {
            _stopwatch.Start();
            _userService.readNotification(HttpContext);

        }



        [Authorize]
        [HttpDelete("v1/user/removeNotification/")]
        public void removeNotification(int id)
        {
            _stopwatch.Start();
            _userService.deleteNotification(HttpContext,id);
        }
      
        
        [Authorize]
        [HttpGet("v1/user/listNotification")]
        public async Task<IActionResult> listNotification()
        {
            _stopwatch.Start();
            var data = await _userService.listNotifications(HttpContext);
            return Json(new { data = data.Data });

        }

       
       [Authorize]
       [HttpGet("v1/user/listContacts")]
       public async Task<IActionResult> listContacts()
       {
           _stopwatch.Start();
           var data = await _userService.listContacts(HttpContext);
           return Json(new { data = data.Data });

       }

        [Authorize]
        [HttpPost("v1/user/addContact/{id}")]
        public async Task<IActionResult> addContact(int id)
        {
            _stopwatch.Start();
            var data = await _userService.addContact(HttpContext, id);
            return Json(new { data = data.Data });

        }

        
        [Authorize]
        [HttpDelete("v1/user/removeContact/{id}")]
        public async Task<IActionResult> removeContact(int id)
        {
            _stopwatch.Start();
            var data = await _userService.removeContact(HttpContext, id);
            return Json(new { data = data.Data });

        }


    }
}
