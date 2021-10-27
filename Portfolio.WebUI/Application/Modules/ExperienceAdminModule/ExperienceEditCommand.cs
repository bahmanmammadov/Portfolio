using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.AppCode.Extension;
using Portfolio.WebUI.Models.DataContext;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.ExperienceModule
{
    public class ExperienceEditCommand : ExperienceViewModel, IRequest<int>
    {


        public class ExperienceEditCommandHandler : IRequestHandler<ExperienceEditCommand, int>
        {
            readonly ResumeDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;


            public ExperienceEditCommandHandler(ResumeDbContext db, IActionContextAccessor ctx, IWebHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(ExperienceEditCommand request, CancellationToken cancellationToken)
            {

                if (request.Id == null || request.Id < 0)
                {
                    return 0;
                }
                var entity = await db.experiences.FirstOrDefaultAsync(r => r.ID == request.Id && r.DeleteByUserId == null);

                if (entity == null)
                {
                    return 0;
                }
                if (ctx.IsModelStateValid())
                {

                    entity.TimeInterval = request.TimeInterval;
                    entity.WorkName = request.WorkName;
                    entity.WorkType = request.WorkType;
                    entity.WorkPlace = request.WorkPlace;
                    entity.Logo = request.Logo;

                    await db.SaveChangesAsync(cancellationToken);
                    return entity.ID;
                }
                return 0;
            }

        }
    }
}