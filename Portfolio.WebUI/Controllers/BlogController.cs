using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    public class BlogController : Controller
    {
        readonly ResumeDbContext db;
        public BlogController(ResumeDbContext db)
        {
            this.db = db;
        }
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
