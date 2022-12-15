using Domain.Interfaces;
using Domain.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;
using System.Diagnostics.CodeAnalysis;

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
        public async Task<IActionResult> GetImmobile(FilterRequest filters)
        {
            _stopwatch.Start();
            return FromResult(await _immobilesService.GetImmobiles(filters));

        }
    }
}
