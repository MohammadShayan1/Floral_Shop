using EcomApp.DataAccessLayer;
using EcomApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Batch_2209e01_EShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly EshopDataContext dbContext;

        public AccountController(EshopDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var admin = dbContext.Admins.FirstOrDefault(a => a.Email == email && a.Password == password);
            
            if (admin != null)
            {
                // Redirect to admin dashboard
                return RedirectToAction("Index", "Admin");
            }
            var user = dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
                {

                // Redirect to user website
                return RedirectToAction("Gallery", "User");
                }
            
            // Invalid credentials
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return RedirectToAction("Login");
            }
            
            return View(user);

        }
       
    }
}
