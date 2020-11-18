using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HerosDB;
using HerosWeb.Models;

namespace HerosWeb.Controllers
{
	public class SuperHeroController : Controller
	{
		private readonly ISuperHeroRepo _repo;
		
		//the argument for this constructor is passed in Startup.cs
		public SuperHeroController(ISuperHeroRepo repo)
        {
			_repo = repo;
        }

		public async Task<IActionResult> GetAllHeroes()
		{
			var superHeroes = await _repo.GetAllHeroesAsync();
			return View(superHeroes);
		}

		public IActionResult GetHeroByName(string name)
        {
			var superHero = _repo.GetHeroByName(name);
			return View(superHero);
        }

		public ViewResult AddHero()
        {
			return View();
        }

		[HttpPost]
		public IActionResult AddHero(SuperHero superHero)
        {
			if(ModelState.IsValid)
            {
				HerosDB.Models.SuperHero hero = new HerosDB.Models.SuperHero();
				hero.Alias = superHero.Alias;
				hero.RealName = superHero.RealName;
				hero.HideOut = superHero.HideOut;
				_repo.AddAHeroAsync(hero);
				return Redirect("GetAllHeroes");
			}
			else { return View(); }
        }

		public ViewResult UpdateHero(string name)
        {
			var superhero = _repo.GetHeroByName(name);
			SuperHero webHero = new SuperHero();
			webHero.Alias = superhero.Alias;
			webHero.HideOut = superhero.HideOut;
			webHero.RealName = superhero.RealName;
			return View(webHero);
        }

		[HttpPost]
		public IActionResult UpdateHero(SuperHero superHero)
        {
			if (ModelState.IsValid)
			{
				HerosDB.Models.SuperHero hero = new HerosDB.Models.SuperHero();
				hero.Alias = superHero.Alias;
				hero.RealName = superHero.RealName;
				hero.HideOut = superHero.HideOut;
				_repo.UpdateHero(hero);
				return Redirect("GetAllHeroes");
			}
			else { return View(); }
		}
	}
}
