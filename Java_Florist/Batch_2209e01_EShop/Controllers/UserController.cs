
using Microsoft.AspNetCore.Mvc;
using EcomApp.DataAccessLayer;

namespace Batch_2209e01_EShop.Controllers
{
    public class UserController : Controller
    {
        private EshopDataContext context;
        public UserController(EshopDataContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
 
            return View();
        }

        public IActionResult About()
        {

            return View();
        }
        public IActionResult Gallery()
        {
            
            var p = context.Products.ToList();
            return View(p);
        }
    }
}
