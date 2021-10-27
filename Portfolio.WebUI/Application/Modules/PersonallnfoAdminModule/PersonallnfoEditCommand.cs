using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.AppCode.Extension;
using Portfolio.WebUI.Models.DataContext;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.PersonallnfoModule
{
    public class PersonallnfoEditCommand : PersonallnfoViewModel, IRequest<int>
    {


        public class PersonallnfoEditCommandHandler : IRequestHandler<PersonallnfoEditCommand, int>
        {
            readonly ResumeDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;


            public PersonallnfoEditCommandHandler(ResumeDbContext db, IActionContextAccessor ctx, IWebHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(PersonallnfoEditCommand request, CancellationToken cancellationToken)
            {

                if (request.Id == null || request.Id < 0)
                {
                    return 0;
                }
                var entity = await db.PersonalInfos.FirstOrDefaultAsync(r => r.ID == request.Id && r.DeleteByUserId == null);

                if (entity == null)
                {
                    return 0;
                }
                if (ctx.IsModelStateValid())
                {

                    entity.Location = request.Location;
                    entity.Degree = request.Degree;
                    entity.PhoneNumber = request.PhoneNumber;
                    entity.Email = request.Email;
                    entity.Experience = request.Experience;
                    entity.CareerLevel = request.CareerLevel;
                    entity.Fax = request.Fax;
                    entity.Website = request.Website;


                    await db.SaveChangesAsync(cancellationToken);
                    return entity.ID;
                }
                return 0;
            }

        }
    }
}