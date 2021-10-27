using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.ViewModel;
using System.Linq;

namespace Portfolio.WebUI.Controllers
{
    [AllowAnonymous]
    public class ResumeController : Controller
    {
        readonly ResumeDbContext db;
        public ResumeController(ResumeDbContext db)
        {
            this.db = db;

        }
        public IActionResult Index()
        {
            var vm = new ResumeViewModel();
            vm.Experiences = db.experiences.Where(b => b.DeleteByUserId == null).ToList();
            vm.Educations = db.Educations.Where(b => b.DeleteByUserId == null).ToList();
            vm.skills = db.Skillss.Where(b => b.DeleteByUserId == null).ToList();

            vm.bios = db.Bios.FirstOrDefault(c => c.DeleteByUserId == null);



            return View(vm);
        }
    }
}
