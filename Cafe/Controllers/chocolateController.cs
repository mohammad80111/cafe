using Cafe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Controllers
{
    [Authorize]
    public class chocolateController : Controller
    {
        private readonly AppDbContext _context;

        public chocolateController(AppDbContext appDb)
        {
            _context = appDb;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<chocolate> lista=_context.chocolates.Include(c=>c.size).ToList();
            return View(lista);
        }
         
      


        [HttpGet]
        public IActionResult Create()
        {
            selectitem();
            return View();
        }


        [HttpPost]
        public IActionResult Create(chocolate chocolate)
        {
            _context.chocolates.Add(chocolate);
            _context.SaveChanges();
            TempData["create"] = "create sucess";

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int? ID)
        {
            selectitem();
            var item = _context.chocolates.Find(ID);
            return View(item);
        }


        [HttpPost]
        public IActionResult Edit(chocolate chocolate)
        {
            _context.chocolates.Update(chocolate);
            _context.SaveChanges();
            TempData["Edit"] = "edit done";

            return RedirectToAction("Index");
        }



        public ViewResult Delete(int ID)
        {
            chocolate C1 = (from cho in _context.chocolates
                            where cho.Id == ID
                            select cho).FirstOrDefault();

            _context.chocolates.Remove(C1);
            _context.SaveChanges();
            List<chocolate> lista = _context.chocolates.Include(c => c.size).ToList();

            return View("Index",lista);
        }

        public void selectitem(int selectid = 0)
        {
            List<Size> lista = _context.Sizes.ToList();
            SelectList selectListItems = new SelectList(lista, "Id", "Name", selectid);
            ViewBag.selecto = selectListItems;
        }


    }
}
