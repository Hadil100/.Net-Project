using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyNewProject.Models;
using MyNewProject.Models.Repositories;
using System.Diagnostics;

namespace MyNewProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository ProductRepository;
        private readonly ICategoryRepository CategoryRepository;
        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            ProductRepository = productRepository;
            this.CategoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var products = ProductRepository.GetAll();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Search(string name, int? CategoryId)

        {
            var result = ProductRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = ProductRepository.FindByName(name);
            else
            if (CategoryId != null)
                result = ProductRepository.GetProductsByCategoryID(CategoryId);
            ViewBag.Categories = new SelectList(CategoryRepository.GetAll(), "CategoryId", "CategoryName");
            return View("Index", result);
        }
    }
}