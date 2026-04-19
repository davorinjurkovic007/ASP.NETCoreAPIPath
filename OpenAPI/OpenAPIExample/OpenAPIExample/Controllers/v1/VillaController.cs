using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenAPIExample.Controllers.v1
{
    [Route("api/v1/villa")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVillas()
        {
            return Ok("Return Villas version 1");
        }
    }
}
