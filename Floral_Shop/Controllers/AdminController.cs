using Microsoft.AspNetCore.Mvc;

namespace Floral_Shop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
