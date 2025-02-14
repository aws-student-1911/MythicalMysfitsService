﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public async Task<ActionResult<List<Mysfit>>> Get([FromQuery] string? filter, [FromQuery] string? value)
        {
            var mysfits = new List<Mysfit>();
            if (String.IsNullOrEmpty(filter) && String.IsNullOrEmpty(value))
            {
                mysfits = await _mysfitsService.GetMysfits();
            }
            else
            {
                mysfits = await _mysfitsService.GetMysfitsWithFilter(new FilterRequest { filter = filter, value = value });
            }
            return new JsonResult(new { mysfits = mysfits });
        }
        // GET api/mysfits/{mysfitId}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Mysfit>> GetMysfit(Guid id)
        {
            return await _mysfitsService.GetMysfitById(id.ToString());
        }
        // POST api/mysfits/{mysfitid}/like
        // [Authorize]
        [HttpPost("{id:guid}/like")]
        public async Task<ActionResult> LikeMysfit(Guid id)
        {
            await _mysfitsService.LikeMysfit(id.ToString());
            return Ok(new { Success = true });
        }
        //POST api/mysfits/{mysfitId}/adopt
        [HttpPost("{id:guid}/adopt")]
        public async Task<ActionResult<String>> AdoptMysfit(Guid id)
        {
            await _mysfitsService.AdoptMysfit(id.ToString());
            return Ok(new { Success = true });
        }
    }
}
