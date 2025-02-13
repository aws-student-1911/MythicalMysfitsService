using Microsoft.AspNetCore.Mvc;

namespace ModernWebAppNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MysfitsController : ControllerBase
    {
        private readonly MysfitsService _mysfitsService;
        public MysfitsController(MysfitsService mysfitsService)
        {
            _mysfitsService = mysfitsService;
        }
        // GET api/mysfits
        [HttpGet]
        public async Task<ActionResult<List<Mysfit>>> Get([FromQuery]FilterRequest filter)
        {
            var mysfits = new List<Mysfit>();
            if (String.IsNullOrEmpty(filter.filter) && String.IsNullOrEmpty(filter.value))
            {
                mysfits = await _mysfitsService.GetMysfits();
            }
            else
            {
                mysfits = await _mysfitsService.GetMysfitsWithFilter(filter);
            }
            return new JsonResult(new { mysfits = mysfits });
        }
    }
}
