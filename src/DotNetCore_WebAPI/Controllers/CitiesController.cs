using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNetCore_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        [HttpGet]
        public ActionResult GetCities()
        {
            return new JsonResult(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult GetCity(int id)
        {
            return new JsonResult(
                CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == id)
                );
        }
    }
}