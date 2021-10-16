using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Models.DataContext;
using System.Linq;

namespace Portfolio.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        readonly ResumeDbContext db;
        public ProjectController(ResumeDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.portfolio
                .Where(b =>b.DeleteByUserId == null)
                .ToList();
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = db.portfolio
                .FirstOrDefault(b => b.ID == id);
            
            return View(data);
        }
    }
}
