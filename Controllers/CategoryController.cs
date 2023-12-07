using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Hosting.Internal;
using MyNewProject.Models;
using MyNewProject.Models.Repositories;
using MyNewProject.ViewModels;
using System.Linq;

namespace MyNewProject.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
      
        private readonly ICategoryRepository CategoryRepository;
        // GET: CategoryController
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.CategoryRepository = categoryRepository;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var categories = CategoryRepository.GetAll();
            return View(categories);
           
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = CategoryRepository.GetById(id);

            return View(category);
        }

        // GET: CategoryController/Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]

        public ActionResult Create(Category categorie)
        {
            try
            {
                CategoryRepository.Add(categorie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = CategoryRepository.GetById(id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                CategoryRepository.Edit(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = CategoryRepository.GetById(id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                CategoryRepository.Delete(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
       /* public ActionResult Search(SearchCategoryViewModel model)
        {
            var result = CategoryRepository.GetByName(model.CategoryName);

            // Mapper votre objet Category vers SearchCategoryViewModel
            var searchResult = new List<SearchCategoryViewModel>
    {
        new SearchCategoryViewModel
        {
            CategoryId = result.CategoryId,
            CategoryName = result.CategoryName
        }
    };

            return View("Index", searchResult);
        }
       */



    }
}
