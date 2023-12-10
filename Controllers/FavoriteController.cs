using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNewProject.Models;
using MyNewProject.Models.Repositories;

namespace MyNewProject.Controllers
{
 
    public class FavoriteController : Controller
    {
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IProductRepository productRepository;
        public FavoriteController(IFavoriteRepository favoriteRepository, IWebHostEnvironment hostingEnvironment, IProductRepository productRepository)
        {
            this.favoriteRepository = favoriteRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.productRepository = productRepository;
           
        }
        // GET: FavoriteController
        public ActionResult Index()
        {
            var favorites = favoriteRepository.getAll();
            return View(favorites);
        }

        public ActionResult AddToFavorites(int  productId)
        {
            Product product = productRepository.Get(productId);
             favoriteRepository.AddToFavorites(product);
            return RedirectToAction("Index");


        }
    }
}
