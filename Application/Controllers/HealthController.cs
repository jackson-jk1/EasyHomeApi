using Service.Helpers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Application.Controllers
{

    [Route("v1/health/")]
    [Produces("application/json")]
 
    public class HealthController : Controller
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet("live")]
        [SwaggerOperation(
        Summary = "EndPoint para Devops"
        )]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        [AllowAnonymous]
        public IActionResult Live()
        {
           return Ok(string.Empty);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpGet("read")]
        [AllowAnonymous]
        [SwaggerOperation(
        Summary = "EndPoint para Devops"
        )]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public IActionResult Read()
        {
          return StatusCode((int)HttpStatusCode.Accepted);
        }
    }
}
