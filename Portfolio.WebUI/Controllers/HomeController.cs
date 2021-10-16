using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Controllers
{
    public class HomeController : Controller
    {

        readonly ResumeDbContext db;
        public HomeController(ResumeDbContext db)
        {
            this.db = db;

        }
        public IActionResult Index()
        {
            return View();
        }

        //+
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();

                return Json(new
                {
                    error = false,
                    message = "Ugurludur"
                });
            }
            return Json(new
            {
                error = true,
                message = "Yeniden sinayin"
            });
        }
    }
}
