using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HerosWeb.Models;

namespace HerosWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		//arguments are passed from the model binder, which automatically
		//searches for the source of the data (e.g. either in a querystring,
		//a formcollection, etc.) or otherwise using the optional values (if
		//specified) or otherwise passes in blank values (e.g. 0 or "")
		public IActionResult Index(int id=5, string name="Superman")
		{
			//SuperHero hero = new SuperHero() { Id = 1, alias = "Thor", name = "Thor" };
			//ViewData["SuperHeroName"] = hero; 
			//ViewBag.SuperHeroName = hero;
			//return View(hero);
			ViewBag.id = id;
			ViewBag.name = name;
			return View();
		}

		public IActionResult About()
        {
			return View();
        }

		/// [] <--- this is an attribute
		/// By default, all of your actions are [HttpGet]
		/// If you specify [HttpPost], you are not returning a view, you are injecting a value
		[Route("{Controller=Home}/{Action=About}/{id?}")] //defining route for this action
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
