using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using MyNewProject.Models;
using MyNewProject.Models.Repositories;
using MyNewProject.ViewModels;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class ProductController : Controller

    {
        readonly IProductRepository ProductRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly ICategoryRepository CategoryRepository;
        // GET: ProductController
        public ProductController(IProductRepository ProductRepository, IWebHostEnvironment hostingEnvironment, ICategoryRepository categoryRepository)
        {
            this.ProductRepository = ProductRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.CategoryRepository = categoryRepository;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Categories = new SelectList(CategoryRepository.GetAll(), "CategoryId", "CategoryName");
            var products = ProductRepository.GetAll();
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {

            ViewBag.Categories = new SelectList(CategoryRepository.GetAll(), "CategoryId", "CategoryName");
            var product = ProductRepository.Get(id);

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(CategoryRepository.GetAll(), "CategoryId", "CategoryName");
            return View();
        }

        /* // POST: ProductController/Create
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create(Product newproduct)
         {
             try
             {

                 sqlProductRepository.Add(newproduct);
                 return RedirectToAction(nameof(Index));
             }
             catch
             {

                 return View();
             }
         }
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            ViewBag.Categories = new SelectList(CategoryRepository.GetAll(), "CategoryId", "CategoryName");
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                // If the Photo property on the incoming model object is not null, then the user has selected an image to upload.
                if (model.ImagePath != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.ImagePath.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Product newProduct = new Product

                {
                    Designation = model.Designation,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    CategoryId = model.CategoryId,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    Image = uniqueFileName
                };
                ProductRepository.Add(newProduct);
                return RedirectToAction("details", new { id = newProduct.Id });
            }
            return View();
        }
        /* // GET: ProductController/Edit/5
         public ActionResult Edit(int id)
         {
             var product = sqlProductRepository.Get(id);
             return View(product);
         }

         // POST: ProductController/Edit/5
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Edit(int id, Product product)
         {
             try
             {
                 sqlProductRepository.Update(product);
                 return RedirectToAction(nameof(Index));
             }
             catch
             {
                 return View();
             }
         }
        */

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(CategoryRepository.GetAll(), "CategoryId", "CategoryName");
            Product product = ProductRepository.Get(id);
            EditViewModel productEditViewModel = new EditViewModel
            {
                Id = product.Id,
                Designation = product.Designation,
                Price = product.Price,
                Quantity = product.Quantity,
                ExistingImagePath = product.Image
            };
            return View(productEditViewModel);
        }

        // POST: ProductController/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel model)
        {
            ViewBag.Categories = new SelectList(CategoryRepository.GetAll(), "CategoryId", "CategoryName");
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the product being edited from the database
                Product product = ProductRepository.Get(model.Id);
                // Update the product object with the data in the model object
                product.Designation = model.Designation;
                product.Price = model.Price;
                product.Quantity = model.Quantity;
                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
                if (model.ImagePath != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (model.ExistingImagePath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingImagePath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the product object which will be
                    // eventually saved in the database
                    product.Image = ProcessUploadedFile(model);
                }

                // Call update method on the repository service passing it the

                // product object to update the data in the database table
                Product updatedProduct = ProductRepository.Update(product);
                if (updatedProduct != null)
                    return RedirectToAction("Index");
                else
                    return NotFound();

            }
            return View(model);
        }
        [NonAction]
        private string ProcessUploadedFile(EditViewModel model)
        {
            string uniqueFileName = null;
            if (model.ImagePath != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagePath.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = ProductRepository.Get(id);


            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                ProductRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


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
