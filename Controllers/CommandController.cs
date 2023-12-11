using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNewProject.Models.Repositories;
using MyNewProject.Models;
namespace MyNewProject.Controllers
{
    public class CommandController : Controller
    {
        private readonly ICommandRepository commandRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        public CommandController(ICommandRepository commandRepository, IWebHostEnvironment hostingEnvironment)
        {
            
            this.hostingEnvironment = hostingEnvironment;
            this.commandRepository = commandRepository;
        }
        // GET: CommandController
        public ActionResult Index()
        {
            var commands = commandRepository.GetAll();
            return View(commands);
        }

        // GET: CommandController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommandController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommandController/Create
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

        // GET: CommandController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommandController/Edit/5
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

        // GET: CommandController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommandController/Delete/5
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

        public ActionResult Valide(int commandId)
        {
            Command command = commandRepository.GetById(commandId);
            command.status = "Valide";
            commandRepository.Add(command);
            return RedirectToAction("Index");
        }
    }
}
