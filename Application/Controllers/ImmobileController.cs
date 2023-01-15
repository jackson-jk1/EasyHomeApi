using Domain.Interfaces;
using Domain.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers;
using Service.Interfaces;

namespace Application.Controllers
{
    public class ImmobileController : ControllerBase
    {
        private readonly IImmobileService _immobilesService;
        public ImmobileController(IImmobileService immobilesService, IlogService logService) : base(logService, "ImmobilesController")
        {
            _immobilesService = immobilesService;
        }

        [HttpPost("v1/immobiles/")]
        public async Task<IActionResult> GetImmobiles([FromBody] FilterRequest filters)
        {
            _stopwatch.Start();
            var data = await _immobilesService.GetImmobiles(filters);
            return Json(new { data = data.Data });

        }


        [HttpPost("v1/immobiles/{id}")]
        public async Task<IActionResult> GetImmobile([FromBody] FilterRequest filters)
        {
            _stopwatch.Start();
            return FromResult(await _immobilesService.GetImmobiles(filters));

        }

        [Authorize]
        [HttpPost("v1/immobiles/getByUser/")]
        public async Task<IActionResult> getImmobileByUser([FromBody] FilterRequest filters)
        {
            _stopwatch.Start();
            var data = await _immobilesService.getImmobileByUser(HttpContext,filters);
            return Json(new { data = data.Data });

        }
    }
}
