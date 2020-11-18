using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerosDB;
using Microsoft.AspNetCore.Mvc;

namespace HerosWeb.Controllers
{
    public class SuperVillainController : Controller
    {
        private IVillainRepo _repo;

        public SuperVillainController(IVillainRepo repo)
        {
            _repo = repo;
        }

        public IActionResult GetAllVillains()
        {
            var villains = _repo.GetAllVillains();
            return View(villains);
        }

        public IActionResult GetVillainByName(string name)
        {
            var villain = _repo.GetVillainByName(name);
            return View(villain);
        }
    }
}
