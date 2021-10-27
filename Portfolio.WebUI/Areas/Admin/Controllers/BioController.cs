using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Appcode.Application.BioModule;
using Portfolio.WebUI.Appcode.Application.BlogMolus;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    [Authorize(Roles ="SuperAdmin")]
    public class BioController : Controller
    {
        private readonly ResumeDbContext db;
        private readonly IWebHostEnvironment env;
        private readonly IMediator mediator;

        public BioController(ResumeDbContext db, IWebHostEnvironment env, IMediator mediator)
        {
            this.db = db;
            this.env = env;
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(BioPagedQuery request)
        {


            var response = await mediator.Send(request);
            if (response== null)
            {
                return NotFound();
            }

            return View(response);
        }

        public async Task<IActionResult> Details(BioSingleQuery query)
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
        public async Task<IActionResult> Create(BioCreateComman command)
        {

            Bio model = await mediator.Send(command);

            if (model != null)

                return RedirectToAction(nameof(Index));

            return View(command);
        }


        public async Task<IActionResult> Edit(BioSingleQuery query)
        {
           Bio bio = await mediator.Send(query);

            if (bio == null)
            {
                return NotFound();
            }
            BioViewModel vm = new BioViewModel();

            vm.Content = bio.Content;

            return View(vm);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BioEditCommand command)
        {

            var id = await mediator.Send(command);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            return View(command);



        }


        [HttpPost]
        public async Task<IActionResult> Delete(BioRemoveCommand requst)
        {
            var respons = await mediator.Send(requst);

            return Json(respons);
        }
    }
}