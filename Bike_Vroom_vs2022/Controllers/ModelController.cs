using Bike_Vroom_vs2022.AddDbContext;
using Bike_Vroom_vs2022.Vroom_Model;
using Bike_Vroom_vs2022.Vroom_Model.ViewModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Bike_Vroom_vs2022.Controllers
{
    public class ModelController : Controller
    {
        private readonly VroomDbContext dbContext;

        [BindProperty]
        private ModelViewModel Modelvm { get; set; }
        public ModelController(VroomDbContext _dbContext)
        {
            dbContext = _dbContext;
            Modelvm = new ModelViewModel()
            {
                Makes = dbContext.Makes.ToList(),
                Model= new  Vroom_Model.Model()
            };
        }
        public IActionResult Index()
        {
            var model = dbContext.Models.Include(m => m.Make);
            return View(model);
        }
        public IActionResult Create()
        {
            return View(Modelvm);
        }

        [HttpPost,ActionName("Create")]
        public IActionResult CreatePost(Model Model)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(Model);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
           return View(Modelvm);
        }
        public IActionResult Edit(int id)
        {
            Modelvm.Model = dbContext.Models.Include(m => m.Make).SingleOrDefault(m => m.Id == id);
            if(Modelvm.Model==null)
            {
                return NotFound();
            }
            return View(Modelvm);
        }
        [HttpPost,ActionName("Edit")]
        public IActionResult EditPost()
        {
            if(!ModelState.IsValid)
            {
                 return View(Modelvm);          
            }
            dbContext.Update(Modelvm);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
