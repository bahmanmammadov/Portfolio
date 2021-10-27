using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Appcode.Application.EducationModule;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class EducationController : Controller
    {
        private readonly ResumeDbContext db;
        private readonly IWebHostEnvironment env;
        private readonly IMediator mediator;

        public EducationController(ResumeDbContext db, IWebHostEnvironment env, IMediator mediator)
        {
            this.db = db;
            this.env = env;
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(ExperiencePagedQuery request)
        {


            var response = await mediator.Send(request);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        public async Task<IActionResult> Details(EducationSingleQuery query)
        {
            var respons = await mediator.Send(query);

            if (respons == null)
            {
                return NotFound();
            }

            return View(respons);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EducationCreateComman command)
        {

            Education model = await mediator.Send(command);

            if (model != null)

                return RedirectToAction(nameof(Index));

            return View(command);
        }


        public async Task<IActionResult> Edit(EducationSingleQuery query)
        {
            Education bio = await mediator.Send(query);

            if (bio == null)
            {
                return NotFound();
            }
            EducationViewModel vm = new EducationViewModel();

            vm.TimeInterval = bio.TimeInterval;
            vm.Occuption = bio.Occuption;
            vm.CompanyName = bio.CompanyName;
            vm.Location = bio.Location;
            vm.LinkForDiplom = bio.LinkForDiplom;

            return View(vm);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EducationEditCommand command)
        {

            var id = await mediator.Send(command);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            return View(command);



        }


        [HttpPost]
        public async Task<IActionResult> Delete(ExperienceRemoveCommand requst)
        {
            var respons = await mediator.Send(requst);

            return Json(respons);
        }
    }
}