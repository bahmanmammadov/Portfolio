using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Appcode.Application.ExperienceModule;
using Portfolio.WebUI.Appcode.Application.PersonallnfoModule;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class PersonallnfoController : Controller
    {
        private readonly ResumeDbContext db;
        private readonly IWebHostEnvironment env;
        private readonly IMediator mediator;

        public PersonallnfoController(ResumeDbContext db, IWebHostEnvironment env, IMediator mediator)
        {
            this.db = db;
            this.env = env;
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(PersonallnfoPagedQuery request)
        {


            var response = await mediator.Send(request);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        public async Task<IActionResult> Details(PersonallnfoSingleQuery query)
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
        public async Task<IActionResult> Create(PersonallnfoCreateComman command)
        {

            PersonalInfo model = await mediator.Send(command);

            if (model != null)

                return RedirectToAction(nameof(Index));

            return View(command);
        }


        public async Task<IActionResult> Edit(PersonallnfoSingleQuery query)
        {
            PersonalInfo bio = await mediator.Send(query);

            if (bio == null)
            {
                return NotFound();
            }
            var vm = new PersonallnfoViewModel();

            vm.Location = bio.Location;
            vm.Degree = bio.Degree;
            vm.PhoneNumber = bio.PhoneNumber;
            vm.Email = bio.Email;
            vm.Experience = bio.Experience;
            vm.CareerLevel = bio.CareerLevel;
            vm.Fax = bio.Fax;
            vm.Website = bio.Website;

            return View(vm);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonallnfoEditCommand command)
        {

            var id = await mediator.Send(command);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            return View(command);



        }


        [HttpPost]
        public async Task<IActionResult> Delete(PersonallnfoRemoveCommand requst)
        {
            var respons = await mediator.Send(requst);

            return Json(respons);
        }
    }
}
