using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNetCore_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}