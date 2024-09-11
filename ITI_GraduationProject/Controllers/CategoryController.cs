using ITI_GraduationProject.Context;
using ITI_GraduationProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_GraduationProject.Controllers
{
    public class CategoryController : Controller
    {
        MyContext db = new MyContext();

        [HttpGet]
        public IActionResult Index()
        {
            var _Categories = db.Categories;
            return View(_Categories);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Category = db.Categories.Find(id);
            if (_Category == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Category category)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                return View();
            }
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _Category = db.Categories.FirstOrDefault(Cat => Cat.Id == id);
            if (_Category == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Category);
        }


        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                return View();
            }
            db.Categories.Update(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var _Category = db.Categories.Find(id);
            if (_Category == null)
            {
                return RedirectToAction("Index");
            }
            db.Categories.Remove(_Category);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
