using BanSach.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using BanSach.Models;
using BanSach.DataAccess.Repository.IRepository;

namespace WebBanSach.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _context;
        public CategoryController(IUnitOfWork context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _context.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("CustomError", "The name must not same display order");
            }
            if (ModelState.IsValid) { 
                _context.Category.Add(obj);
                _context.Save();
                TempData["Sucess"]= "Create category sucessesfull";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id ==null || id== 0)
            {
                return NotFound();
            }
            var category = _context.Category.GetItem(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("CustomError", "The name must not same display order");
            }
            if (ModelState.IsValid)
            {
                _context.Category.Update(obj);
                _context.Save();
                TempData["Sucess"] = "Update category sucessesfull";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.Category.GetItem(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            if (obj == null)
            {
                return NotFound();
            }else
            {
                _context.Category.Delete(obj);
                _context.Save();
                TempData["Sucess"] = "Delete category sucessesfull";
                return RedirectToAction("Index");
            }
            
        }

        
    }
}
