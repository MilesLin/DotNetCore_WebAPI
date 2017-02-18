using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotNetCore_WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        [HttpGet]
        public ActionResult GetCities()
        {
            return new JsonResult(new List<object>()
            {
                new { id = 1, Name = "New York City"},
                new { id = 2, Name = "Antwerp"},
            });
        }
    }
}
