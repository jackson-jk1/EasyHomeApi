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
        public async Task<IActionResult> getImmobiles([FromBody] FilterRequest filters)
        {
            _stopwatch.Start();
            var data = await _immobilesService.getImmobiles(filters);
            return Json(new { data = data.Data });

        }


        [HttpPost("v1/immobiles/{id}")]
        public async Task<IActionResult> getImmobile([FromBody] FilterRequest filters)
        {
            _stopwatch.Start();
            return FromResult(await _immobilesService.getImmobiles(filters));

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
