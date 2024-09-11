using ITI_GraduationProject.Context;
using ITI_GraduationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_GraduationProject.Controllers
{
    public class UserController : Controller
    {
        MyContext db = new MyContext();



        [HttpGet]
        public IActionResult Index()
        {
            var _Users = db.Users;
            return View(_Users);
        }



        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Users = new SelectList(db.Users, "Id", "FirstName", "LastName");
            return View();
        }



        [HttpPost]
        public IActionResult Create(User user)
        {
            // Check if a user with the same email already exists
            var existingUser = db.Users.FirstOrDefault(u => u.Email == user.Email);

            if (existingUser != null)
            {
                return Content("A user with this email already exists.");
            }
            ModelState.Remove("User");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                ViewBag._Users = new SelectList(db.Users, "Id", "FirstName", "LastName");
                return View();
            }
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }


        public IActionResult Delete(int id)
        {
            var _User = db.Users.Find(id);
            if (_User == null)
            {
                return RedirectToAction("Index");
            }
            db.Users.Remove(_User);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Login(string email, string password)
        {
            var user = db.Users.FirstOrDefault(o => o.Email == email && o.Password == password);
            if (user != null)
            {
                // Email and password exist
                return RedirectToAction("Index", "Product");
            }
            else
            {
                // Email and password do not exist
                return Content(" Email Or password do not exists.");
            }

        }
    }
}
