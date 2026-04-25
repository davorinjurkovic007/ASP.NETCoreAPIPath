using Asp.Versioning;
using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CityInfo.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Authorize]
    //[Route("api/[controller]")]
    //[Route("api/cities")]
    [ApiVersion(1)]
    [ApiVersion(2)]
    [Route("api/v{version:apiVersion}/cities")]
    //[ApiExplorerSettings(GroupName = "v1")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        const int maxCitiesPageSize = 20;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityInfoRepository"></param>
        /// <param name="mapper"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CitiesController(ICityInfoRepository cityInfoRepository,
            IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="searchQuery"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities(
            /*[FromQuery(Name = "filteronname")]*/ string? name, string? searchQuery, 
                int pageNumber = 1, int pageSize = 10)
        {
           //return new JsonResult(
           //     new List<object>
           //     {
           //         new { id = 1, Name = "New York City" },
           //         new { id = 2, Name = "Antwerp" }
           //     });

            //return Ok(_citiesDataStore.Cities);

            if(pageSize > maxCitiesPageSize)
            {
                pageSize = maxCitiesPageSize;
            }

            var (cityEntities, paginationMetadata) = await _cityInfoRepository
                .GetCitiesAsync(name, searchQuery, pageNumber, pageSize);

            Response.Headers.TryAdd("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            var testingMapper = _mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));

            //return Ok();

            //var results = new List<CityWithoutPointsOfInterestDto>();
            //foreach (var cityEntity in cityEntities)
            //{
            //    results.Add(new CityWithoutPointsOfInterestDto
            //    { 
            //        Id = cityEntity.Id,
            //        Description = cityEntity.Description,
            //        Name = cityEntity.Name,
            //    });
            //}

            //return Ok(results);
        }

        /// <summary>
        /// Get a city by id
        /// </summary>
        /// <param name="id">The id of the city to get</param>
        /// <param name="includePointsOfInterest">Whether or not to include the points of interest</param>
        /// <returns>A city with or without points of interest</returns>
        /// <response code="200">Returns the requested city</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);
            if (city == null) 
            {
                return NotFound();
            }

            if (includePointsOfInterest) 
            {
                return Ok(_mapper.Map<CityDto>(city));
            }

            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
        }
    }
}
