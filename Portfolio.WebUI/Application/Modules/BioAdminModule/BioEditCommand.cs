using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Appcode.Application.BlogMolus;
using Portfolio.WebUI.Appcode.Application.EducationModule;
using Portfolio.WebUI.AppCode.Extension;
using Portfolio.WebUI.Models.DataContext;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.BioModule
{
    public class BioEditCommand : BioViewModel, IRequest<int>
    {


        public class BioEditCommandHandler : IRequestHandler<BioEditCommand, int>
        {
            readonly ResumeDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;


            public BioEditCommandHandler(ResumeDbContext db, IActionContextAccessor ctx, IWebHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(BioEditCommand request, CancellationToken cancellationToken)
            {

                if (request.Id == null || request.Id < 0)
                {
                    return 0;
                }
                var entity = await db.Bios.FirstOrDefaultAsync(r => r.ID == request.Id && r.DeleteByUserId == null);

                if (entity == null)
                {
                    return 0;
                }
                if (ctx.IsModelStateValid())
                {
                    entity.Content = request.Content;

                    await db.SaveChangesAsync(cancellationToken);
                    return entity.ID;
                }
                return 0;
            }

        }
    }
}