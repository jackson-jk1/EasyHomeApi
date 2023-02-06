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
     
        public async Task<IActionResult> register([FromForm] UserRequest user)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
            {

                return FromResult(ModelState);
            }
            return FromResult(await _userService.register(user));
            
        }

        // POST: UserController/Edit/5
        [AllowAnonymous]
        [HttpPost("v1/user/auth")]
 
   
        public async Task<IActionResult> auth([FromBody] LoginRequest login)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
            {
                return FromResult(ModelState);
            }
            return FromResult(await _userService.auth(login));

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
        [HttpPost("v1/user/getContact/{idContact}")]
        public async Task<IActionResult> getContact(int idContact)
        {
            _stopwatch.Start();
            var data = await _userService.getContact(HttpContext, idContact);
            return Json(new { data = data.Data });

        }
        [Authorize]
        [HttpPost("v1/user/addContact/{id}/{notId}")]
        public async Task<IActionResult> addContact(int id, int notId)
        {
            _stopwatch.Start();
            var data = await _userService.addContact(HttpContext, id, notId);
            return Json(new { data = data.Data });

        }
        [Authorize]
        [HttpGet("v1/user/")]
        public async Task<IActionResult> getUser()
        {
            _stopwatch.Start();
            return FromResult(await _userService.getByToken(HttpContext));

        }

        [Authorize]
        [HttpGet("v1/user/{contactId}")]
        public async Task<IActionResult> getContactById(int contactId)
        {
            _stopwatch.Start();
            return FromResult(await _userService.getById(contactId));

        }

        [Authorize]
        [HttpGet("v1/user/preference/{id}")]
        public async Task<IActionResult> checkImmobile(int id)
        {
            _stopwatch.Start();
            var data = await _userService.checkImmobile(HttpContext, id);
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
        [HttpGet("v1/user/listContacts")]
        public async Task<IActionResult> listContacts()
        {
            _stopwatch.Start();
            var data = await _userService.listContacts(HttpContext);
            return Json(new { data = data.Data });

        }



        [HttpPut("v1/user/")]
        [Authorize]
        public async Task<IActionResult> update([FromForm] UserRequest user)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid && user.Image != null)
            {
                return FromResult(ModelState);
            }
            return FromResult(await _userService.update(HttpContext, user));

        }

        [HttpPut("v1/user/password")]
        [Authorize]
        public async Task<IActionResult> updatePassword([FromBody] PasswordRequest pass)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
            {
                return FromResult(ModelState);
            }
            return FromResult(await _userService.updatePassword(HttpContext, pass));

        }

        [AllowAnonymous]
        [HttpPut("v1/user/{email}")]

        public async Task<IActionResult> recover([FromRoute] string email)
        {

            return FromResult(await _userService.recover(email));

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
        [HttpDelete("v1/user/removeContact/{id}")]
        public async Task<IActionResult> removeContact(int id)
        {
            _stopwatch.Start();
            var data = await _userService.removeContact(HttpContext, id);
            return Json(new { data = data.Data });

        }


    }
}
