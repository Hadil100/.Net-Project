using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNewProject.Models;
using MyNewProject.Models.Repositories;

namespace MyNewProject.Controllers
{
    public class DetailsCommandController : Controller
    {
        private readonly IDetailsRepository detailRepository;
        private readonly IProductRepository productRepository;
        public DetailsCommandController(IDetailsRepository detailRepository, IProductRepository productRepository)
        {
            this.detailRepository = detailRepository;
            this.productRepository = productRepository;
        }
        // GET: DetailsCommandController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DetailsCommandController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetailsCommandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailsCommandController/Create
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

        // GET: DetailsCommandController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetailsCommandController/Edit/5
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

        // GET: DetailsCommandController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetailsCommandController/Delete/5
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
        public ActionResult ViewDetails(int commandId)
        {
            DetailsCommand detailCommand = detailRepository.GetByCommandId(commandId);

            detailCommand.Product = productRepository.Get(detailCommand.ProductId);
  
           
            return View("ViewDetails", detailCommand);
        }

    }
}
