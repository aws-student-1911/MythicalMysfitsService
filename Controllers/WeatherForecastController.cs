using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModernWebAppNET.Controllers
{
    public class Mysfit
    {
        public Guid MysfitId { get; set; }        // Unique identifier (GUID) for the mysfit
        public string Name { get; set; }           // Name of the mysfit
        public string Species { get; set; }        // Species (e.g., Chimera)
        public int Age { get; set; }               // Age of the mysfit
        public string Description { get; set; }    // Detailed description of the mysfit
        public string Goodevil { get; set; }       // Alignment: Good or Evil
        public string Lawchaos { get; set; }       // Alignment: Lawful or Chaotic
        public string ThumbImageUri { get; set; }  // URI for the thumbnail image
        public string ProfileImageUri { get; set; }// URI for the profile image
    }

    [Route("api/[controller]")]
    [ApiController]
    public class MysfitsController : ControllerBase
    {
        // GET api/mysfits
        [HttpGet]
        public IActionResult Get()
        {
            using (var r = new StreamReader("./mysfits-response.json"))
            {
                var json = r.ReadToEnd();
                var parsedJson = JsonConvert.DeserializeObject<Dictionary<string, List<Mysfit>>>(json);
                return new JsonResult(parsedJson["mysfits"]);  // Return just the list
            }
        }

        [HttpGet("test")]
        public IActionResult Get2()
        {
            return Ok("fuck you");
        }

    }

    [Route("/")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        // GET /
        // Used for NLB HealthCheck
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

    }
}
