using Bike_Vroom_vs2022.AddDbContext;
using Bike_Vroom_vs2022.Vroom_Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Bike_Vroom_vs2022.Controllers
{
    public class MakeController : Controller
    {
        private readonly VroomDbContext dbContext;
        public MakeController(VroomDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            return View(dbContext.Makes.ToList());
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Make make) 
        {
            if(ModelState.IsValid)
            {
                dbContext.Makes.Add(make);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Delete(int Id)
        {
            var make = dbContext.Makes.Find(Id);
            if(make == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Makes.Remove(make);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult Edit(int Id)
        {
            var make = dbContext.Makes.Find(Id);
            if (make == null)
            {
                return NotFound();
            }
            return View(make);
        }

        [HttpPost]
        public IActionResult Edit(Make make)
        {
            if (ModelState.IsValid)
            {
                dbContext.Makes.Update(make);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(make);
        }
    }
}
