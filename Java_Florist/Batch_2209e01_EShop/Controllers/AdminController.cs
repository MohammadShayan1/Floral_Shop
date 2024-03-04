
using EcomApp.DataAccessLayer.InfraStructure.IRepository;
using EcomApp.Models;
using EcomApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;

namespace Batch_2209e01_EShop.Controllers
{
    public class AdminController : Controller
    {
        private IUnitofWork _unitofwork;
        private IWebHostEnvironment _hostingEnvironment;
        public AdminController(IUnitofWork unitofWork , IWebHostEnvironment hostingEnvironment)
        {
            _unitofwork = unitofWork;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {

            return View();
        }


        //this method will only return View
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.CategoryRepository.Add(category);
                _unitofwork.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public IActionResult ViewCategory()
        {
            //select * from table Category
            IEnumerable<Category> categories = _unitofwork.CategoryRepository.GetAll();
            return View(categories);
        }

        //this method will only retrun view with selected category
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitofwork.CategoryRepository.GetT(x=>x.C_Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var category = _unitofwork.CategoryRepository.GetT(x => x.C_Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitofwork.CategoryRepository.Delete(category);
            _unitofwork.Save();
            return RedirectToAction("ViewCategory");

        }


        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var category = _unitofwork.CategoryRepository.GetT(x => x.C_Id == id);
            if (category==null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
           if(ModelState.IsValid)
            {
                _unitofwork.CategoryRepository.Update(category);
                _unitofwork.Save();
                return RedirectToAction("ViewCategory");
            }
           return RedirectToAction("ViewCategory");
        }


        //THIS METHOD WILL RETURN VIEW ONLY
        public IActionResult CreateUpdate_Product(int? id)
        {
            ProductVM vm = new ProductVM()
            {
                Product = new(),
                Categoires = _unitofwork.CategoryRepository.GetAll().Select(x => new SelectListItem()
                {
                    Text = x.C_Name,
                    Value = x.C_Id.ToString()
                })
                
            };
            if(id == null || id==0) 
            {
                return View(vm);
            }
            else
            {
                vm.Product = _unitofwork.productRepository.GetT(x => x.Id == id);
                if(vm.Product == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
          
        }



        //This method is for product uploading in database with category name
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate_Product(ProductVM vm, IFormFile? file)
        {
            if(ModelState.IsValid)
            {
                string filename = String.Empty;
                if (file!=null)
                {
                    string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath,"ProductImages");
                    filename = Guid.NewGuid().ToString()+" - "+file.FileName;
                    string filePath = Path.Combine(uploadDir,filename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    vm.Product.ImageURL = @"\ProductImages\"+filename;
                }

                if(vm.Product.Id==0)
                {
                    _unitofwork.productRepository.Add(vm.Product);
                }
                _unitofwork.Save();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }


        
        public IActionResult ViewProduct()
        {
            IEnumerable<Product> products = _unitofwork.productRepository.GetAll();
            return View(products);
           
        }


    }


}
