using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNewProject.Models.Repositories;
using System.Data;

namespace MyNewProject.Controllers
{
    //[Authorize(Roles = "User")]
    public class UserController : Controller
    {
        // GET: UserController
        private readonly IProductRepository ProductRepository;
        private readonly ICategoryRepository CategoryRepository;
        /*private readonly IFavoritesRepository _favoritesRepository;*/

        public UserController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            /*_favoritesRepository = favoritesRepository;*/
            ProductRepository = productRepository;
            this.CategoryRepository = categoryRepository;
        }
        // GET: UserController
        public ActionResult Index()
        {
            var products = ProductRepository.GetAll();
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
    }
}
