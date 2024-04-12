using Microsoft.AspNetCore.Mvc;
using MongoDbCrud1AspNetCoreMVC.Models;
using MongoDbCrud1AspNetCoreMVC.Services;

namespace MongoDbCrud1AspNetCoreMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly MongoDbService _mongoDbService;

        public PersonController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public async Task<IActionResult> Index()
        {
            var persons = await _mongoDbService.GetAll();
            return View(persons);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            ModelState.Remove(nameof(person.PersonId));
            if (ModelState.IsValid)
            {
                await _mongoDbService.Create(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var person = await _mongoDbService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, Person person)
        {
            if (ModelState.IsValid)
            {
                await _mongoDbService.Update(id, person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var person = await _mongoDbService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var person = await _mongoDbService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _mongoDbService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
