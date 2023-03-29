using Microsoft.AspNetCore.Mvc;
using Workshop02.Data;
using Workshop02.Models;

namespace Workshop02.Controllers
{
    public class FoodController : Controller
    {
        IFoodRepository repository;

        public FoodController(IFoodRepository repository)
        {
            this.repository = repository;
        }
        [OutputCache(Duration = 2, VaryByParam = "none")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(this.repository.Read()); 
        }
        [HttpPost]
        public IActionResult Index(string filter)
        {
            if (filter != null && filter != "all")
            {
                var read = repository.ReadFilter(filter);
                read.Selected = filter;
                return View(read);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Food food)
        {
            if(!ModelState.IsValid)
            {
                return View(food);
            }
            repository.Create(food);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(string id)
        {
            var food = repository.Read(id);
            return View(food);
        }
        [HttpPost]
        public IActionResult Update(Food food)
        {
            if(!ModelState.IsValid)
            {
                return View(food);
            }
            repository.Update(food);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult GetImage(string id)
        {
            var food = repository.Read(id);
            if(food.ContentType?.Length > 3)
            {
                return new FileContentResult(food.Data, food.ContentType);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
