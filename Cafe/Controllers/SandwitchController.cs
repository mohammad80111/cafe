using Cafe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Controllers
{
    [Authorize]
    public class SandwitchController : Controller
    {
        private readonly AppDbContext _context;

        public SandwitchController(AppDbContext appDb)
        {
            
            _context = appDb;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<Sandwitch> lista=_context.Sandswitches.Include(x=>x.Spicy).ToList();
            return View(lista);
        }




        [HttpGet]
        public IActionResult Create()
        {
            selectlist();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sandwitch sandwitch)
        {
            _context.Sandswitches.Add(sandwitch);
            _context.SaveChanges();
            TempData["create"] = "create sucess";

            return RedirectToAction("Index");
        }




        [HttpGet]
        public IActionResult Edit(int? ID)
        {
            selectlist();
            var anything = _context.Sandswitches.Find(ID);
            return View(anything);
        }

        [HttpPost]
        public IActionResult Edit(Sandwitch sandwitch)
        {
            _context.Sandswitches.Update(sandwitch);
            _context.SaveChanges();
            TempData["Edit"] = "edit done";

            return RedirectToAction("Index");
        }




        public ViewResult Delete(int ID)
        {
            Sandwitch S1=(from sand in _context.Sandswitches
                          where sand.Id==ID
                          select sand).FirstOrDefault();

            _context.Sandswitches.Remove(S1);
            _context.SaveChanges();
            TempData["Delete"] = "Delete done";
            List<Sandwitch> lista = _context.Sandswitches.Include(x => x.Spicy).ToList();
            return View("Index",lista);
        }



        public void selectlist(int selectid=0)
        {
            List<Spicy> spicies=_context.Spicys.ToList();
            SelectList selectListItems = new SelectList(spicies, "SpicyId", "Name", selectid);
            ViewBag.selecto = selectListItems;
        }

    }
}
