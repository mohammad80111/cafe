using Cafe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Controllers
{
    [Authorize]
    public class IceCreamController : Controller
    {
        private readonly AppDbContext _context;

        public IceCreamController(AppDbContext appDb)
        {
            _context = appDb;
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<IceCream> lista=_context.iceCreams.Include(c=>c.size).ToList();
            return View(lista);
        }

        [HttpGet]
       
        public IActionResult Create()
        {
            selectlist();
            return View();

        }


        [HttpPost]
        public IActionResult Create(IceCream iceCream)
        {
            _context.iceCreams.Add(iceCream);
            _context.SaveChanges();
            TempData["create"] = "create sucess";

            return RedirectToAction("Index");

        }



        [HttpGet]

        public IActionResult Edit(int? ID)
        {
            selectlist();
            var item=_context.iceCreams.Find(ID);
            return View(item);

        }


        [HttpPost]
        public IActionResult Edit(IceCream iceCream)
        {
            _context.iceCreams.Update(iceCream);
            _context.SaveChanges();
            TempData["Edit"] = "edit done";

            return RedirectToAction("Index");

        }




        public ViewResult Delete(int ID) 
        {
            IceCream I1=(from ice in _context.iceCreams
                         where ice.id==ID
                         select ice).FirstOrDefault();

            _context.iceCreams.Remove(I1);
            _context.SaveChanges();
            TempData["Delete"] = "Delete done";

            List<IceCream> lista = _context.iceCreams.Include(c => c.size).ToList();

            return View("Index",lista);
        }



        public void selectlist(int selectid=0)
        {
            List<Size> listaa=_context.Sizes.ToList();
            SelectList selectListItems = new SelectList(listaa, "Id", "Name", selectid);
            ViewBag.selecto = selectListItems;
        }
    }
}
