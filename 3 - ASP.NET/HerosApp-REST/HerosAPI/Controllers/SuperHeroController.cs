using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerosDB.Models;
using HerosLib;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HerosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly IHeroService _heroService;
        public SuperHeroController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpGet("get")]
        //[Produces("application/xml")] //returns in xml format
        [FormatFilter] //returns default (JSON) unless specfied by an "Accept" header
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetAllHeroes()
        {
            try
            {
                return Ok(_heroService.GetAllHeroes());
            }
            catch (Exception)
            {
                return StatusCode(500); //returns status code 500, internal server error
            }
        }

        [HttpGet("get/{name}")]
        [Produces("application/json")]
        [EnableCors("_myAllowSpecificOrigins")]
        public IActionResult GetHeroByName(string name)
        {
            try
            {
                return Ok(_heroService.GetHeroByName(name));
            }
            catch (Exception)
            {
                return NotFound(); //returns error 404?
            }

        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddHero(SuperHero newSuperHero)
        {
            try
            {
                _heroService.AddHero(newSuperHero);
                return CreatedAtAction("AddHero", newSuperHero);
            }
            catch (Exception)
            {
                return BadRequest(); //client-side error
            }
        }
    }
}
