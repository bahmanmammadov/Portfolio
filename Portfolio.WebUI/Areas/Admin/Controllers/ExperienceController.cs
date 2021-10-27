using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Appcode.Application.ExperienceModule;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ExperienceController : Controller
    {
        private readonly ResumeDbContext db;
        private readonly IWebHostEnvironment env;
        private readonly IMediator mediator;

        public ExperienceController(ResumeDbContext db, IWebHostEnvironment env, IMediator mediator)
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

        public async Task<IActionResult> Details(ExperienceSingleQuery query)
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
        public async Task<IActionResult> Create(ExperienceCreateComman command)
        {

            Experience model = await mediator.Send(command);

            if (model != null)

                return RedirectToAction(nameof(Index));

            return View(command);
        }


        public async Task<IActionResult> Edit(ExperienceSingleQuery query)
        {
            Experience bio = await mediator.Send(query);

            if (bio == null)
            {
                return NotFound();
            }
            var vm = new ExperienceViewModel();

            vm.TimeInterval = bio.TimeInterval;
            vm.WorkName = bio.WorkName;
            vm.WorkPlace = bio.WorkPlace;
            vm.WorkType = bio.WorkType;

            return View(vm);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExperienceEditCommand command)
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
