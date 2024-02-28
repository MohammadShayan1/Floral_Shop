using Microsoft.AspNetCore.Mvc;

namespace App_For_Students.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
