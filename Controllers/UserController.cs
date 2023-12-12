using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyNewProject.Models;
using MyNewProject.Models.Repositories;
using System.Data;

namespace MyNewProject.Controllers
{
    //[Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly IProductRepository ProductRepository;
        private readonly ICategoryRepository CategoryRepository;
     
        public UserController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            
            this.ProductRepository = productRepository;
            this.CategoryRepository = categoryRepository;
           
        }
       
        /*private readonly IFavoritesRepository _favoritesRepository;*/

       
        // GET: UserController
        public ActionResult Index()
        {
            var products = ProductRepository.GetAll();
            ViewBag.Categories = new SelectList(CategoryRepository.GetAll(), "CategoryId", "CategoryName");
            return View(products);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
		/*[HttpPost]
        public IActionResult AddToFavorites(int productId)
        {
            
            var userId = "user123"; 

           
            if (!_favoritesRepository.IsProductInFavorites(userId, productId))
            {
                
                _favoritesRepository.AddToFavorites(userId, productId);
            }

           
            return RedirectToAction("Details", "Product", new { id = productId });
        }*/
		public ActionResult Search(string name, int? CategoryId)
		{
			var result = ProductRepository.GetAll();

			if (!string.IsNullOrEmpty(name))
			{
				result = result.Where(p => p.Designation.Contains(name, StringComparison.OrdinalIgnoreCase));
			}

			if (CategoryId != null)
			{
				result = result.Where(p => p.CategoryId == CategoryId);
			}

			ViewBag.Categories = new SelectList(CategoryRepository.GetAll(), "CategoryId", "CategoryName");
			return View("Index", result);
		}


    }
}
