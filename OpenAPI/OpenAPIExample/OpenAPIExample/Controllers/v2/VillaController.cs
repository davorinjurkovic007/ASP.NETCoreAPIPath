using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenAPIExample.Controllers.v2
{
    [Route("api/v2/villa")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetVillas(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
        {
            return Ok("Return Villas number v2");
        }
    }
}
