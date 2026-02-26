using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
           //return new JsonResult(
           //     new List<object>
           //     {
           //         new { id = 1, Name = "New York City" },
           //         new { id = 2, Name = "Antwerp" }
           //     });

            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id:int}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            // find city
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == id);

            if (cityToReturn == null) 
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}
