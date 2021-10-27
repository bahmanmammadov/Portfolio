using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Models.DataContext;
using System.Linq;

namespace Portfolio.WebUI.Controllers
{

    public class BlogController : Controller
    {
        readonly ResumeDbContext db;
        public BlogController(ResumeDbContext db)
        {
            this.db = db;
        }
        [AllowAnonymous]

        public IActionResult Index()
        {

            var data = db.blogposts
                .Where(b => b.PublishDate != null && b.DeleteByUserId == null)
                .ToList();

            return View(data);
        }
        public IActionResult Details(int id)
        {

            var data = db.blogposts.FirstOrDefault(b => b.ID == id);
            return View(data);
        }
    }
}
