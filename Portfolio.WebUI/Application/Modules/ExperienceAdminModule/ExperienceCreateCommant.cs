using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Portfolio.WebUI.AppCode.Extension;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.ExperienceModule
{

    public class ExperienceCreateComman : IRequest<Experience>
    {
        public string WorkName { get; set; }
        public string WorkType { get; set; }
        public string WorkPlace { get; set; }
        public int TimeInterval { get; set; }
        public string Logo { get; set; }



        public class ExperienceCreateCommanHandler : IRequestHandler<ExperienceCreateComman, Experience>
        {
            readonly ResumeDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;
            public ExperienceCreateCommanHandler(ResumeDbContext db, IActionContextAccessor ctx, IWebHostEnvironment env) //Model.State burda yoxlamaq ucun yazilib.
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<Experience> Handle(ExperienceCreateComman model, CancellationToken cancellationToken)
            {


                if (ctx.IsModelStateValid())
                {
                    Experience bio = new Experience();
                    bio.TimeInterval = model.TimeInterval;
                    bio.WorkName = model.WorkName;
                    bio.WorkType = model.WorkType;
                    bio.WorkPlace = model.WorkPlace;
                    bio.Logo = model.Logo;


                    db.experiences.Add(bio);
                    await db.SaveChangesAsync(cancellationToken);
                    return bio;
                }
                return null;
            }
        }
    }
}