using ITI_GraduationProject.Context;
using ITI_GraduationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_GraduationProject.Controllers
{
    public class ProductController : Controller
    {
        MyContext db = new MyContext();


        [HttpGet]
        public IActionResult Index()
        {
            var _Products = db.Products.Include(Pro => Pro.Category);
            return View(_Products);
        }


        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Product = db.Products.Include(e => e.Category).FirstOrDefault(Pro => Pro.Id == id);
            if (_Product == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Product);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Categories = new SelectList(db.Categories, "Id", "Name", "Description");
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Categories = new SelectList(db.Categories, "Id", "Name", "Description");
                return View();
            }
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _Product = db.Products.Include(e => e.Category).FirstOrDefault(Pro => Pro.Id == id);
            if (_Product == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag._Categories = new SelectList(db.Categories, "Id", "Name", "Description");
            return View(_Product);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Categories = new SelectList(db.Categories, "Id", "Name", "Description");
                return View();
            }
            db.Products.Update(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var _Product = db.Products.Find(id);
            if (_Product == null)
            {
                return RedirectToAction("Index");
            }
            db.Products.Remove(_Product);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
