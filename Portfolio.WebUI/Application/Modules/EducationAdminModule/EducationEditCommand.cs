using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Appcode.Application.EducationModule;
using Portfolio.WebUI.AppCode.Extension;
using Portfolio.WebUI.Models.DataContext;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.EducationModule
{
    public class EducationEditCommand : EducationViewModel, IRequest<int>
    {


        public class EducationEditCommandHandler : IRequestHandler<EducationEditCommand, int>
        {
            readonly ResumeDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;


            public EducationEditCommandHandler(ResumeDbContext db, IActionContextAccessor ctx, IWebHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(EducationEditCommand request, CancellationToken cancellationToken)
            {

                if (request.Id == null || request.Id < 0)
                {
                    return 0;
                }
                var entity = await db.Educations.FirstOrDefaultAsync(r => r.ID == request.Id && r.DeleteByUserId == null);

                if (entity == null)
                {
                    return 0;
                }
                if (ctx.IsModelStateValid())
                {

                    entity.TimeInterval = request.TimeInterval;
                    entity.Occuption = request.Occuption;
                    entity.CompanyName = request.CompanyName;
                    entity.Location = request.Location;
                    entity.LinkForDiplom = request.LinkForDiplom;

                    await db.SaveChangesAsync(cancellationToken);
                    return entity.ID;
                }
                return 0;
            }

        }
    }
}