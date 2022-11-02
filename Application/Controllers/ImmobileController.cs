using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    public class ImmobileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
