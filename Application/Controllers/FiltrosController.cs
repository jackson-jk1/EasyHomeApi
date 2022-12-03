using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Services;

namespace Application.Controllers
{
    public class FiltrosController : ControllerBase
    {
        private readonly IFiltrosService _filtrosService;


        public FiltrosController(IFiltrosService filtrosService, IlogService logService) : base(logService, "FiltorsController")
        {
            _filtrosService = filtrosService;
        }

        [HttpGet("v1/polo/")]
        public async Task<IActionResult> GetAll()
        {
            _stopwatch.Start();
            return FromResult(await _filtrosService.GetAllPolos());

        }
    }
}
