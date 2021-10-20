using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.ViewModel;
using System.Linq;

namespace Portfolio.WebUI.Controllers
{
    public class HomeController : Controller
    {

        readonly ResumeDbContext db;
        readonly IMediator mediator;


        public HomeController(ResumeDbContext db)
        {
            this.db = db;

        }
        public IActionResult Index()
        {
            var vm = new IndexViewModel();
            vm.skills = db.Skillss.Where(b => b.DeleteByUserId == null).ToList();
            vm.Services = db.Services.Where(b => b.DeleteByUserId == null)
                .Include(c => c.icons)
                .ToList();
            vm.PersonalInfos = db.PersonalInfos.FirstOrDefault(c => c.DeleteByUserId == null);
            return View(vm);
        }

        //+
        public IActionResult Contact()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Contact(ContactCreateCommand contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Contact contac = await mediator.Send(contact);
        //        if (contac == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(contac);

        //    }

        //}
    } 
}
