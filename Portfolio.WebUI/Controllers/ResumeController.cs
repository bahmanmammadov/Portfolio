using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Portfolio.WebUI.Models.DataContext;

namespace Portfolio.WebUI.Controllers
{
    public class ResumeController : Controller
    {
        readonly ResumeDbContext db;
        public ResumeController(ResumeDbContext db)
        {
            this.db = db;

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
