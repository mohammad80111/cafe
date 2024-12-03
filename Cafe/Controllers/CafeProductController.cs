using Cafe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Controllers
{
    [Authorize]
    public class CafeProductController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CafeProductController(AppDbContext appDbContext)
        {
            
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<CafeProduct> lista=_appDbContext.CafeProducts.Include(c=>c.Size).ToList();
            return View(lista);
        }


        [HttpGet]
        public IActionResult Create()
        {
            selectlist();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CafeProduct cafeProduct)
        {
            _appDbContext.CafeProducts.Add(cafeProduct);
            _appDbContext.SaveChanges();
            TempData["create"] = "create sucess";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int? ID)
        {
            var cafeProduct = _appDbContext.CafeProducts.Find(ID);
            selectlist();
            return View(cafeProduct);
        }

        [HttpPost]
        public IActionResult Edit(CafeProduct cafeProduct)
        {
            _appDbContext.CafeProducts.Update(cafeProduct);
            _appDbContext.SaveChanges();
            TempData["Edit"] = "edit done";
            return RedirectToAction("Index");
        }




        public ViewResult Delete(int ID) 
        {
            CafeProduct C1=(from caf in _appDbContext.CafeProducts
                            where caf.ID == ID
                            select caf).FirstOrDefault();
            _appDbContext.CafeProducts.Remove(C1);
            _appDbContext.SaveChanges();
            TempData["Delete"] = "Delete done";

            List<CafeProduct> lista = _appDbContext.CafeProducts.Include(c => c.Size).ToList();

            return View("Index",lista);

        }

        public void selectlist(int selectid=0)
        {
            List<Size> sizes=_appDbContext.Sizes.ToList();

            SelectList selectListItems = new SelectList(sizes, "Id", "Name",selectid);
            ViewBag.selecto = selectListItems;
        }

    }
}
