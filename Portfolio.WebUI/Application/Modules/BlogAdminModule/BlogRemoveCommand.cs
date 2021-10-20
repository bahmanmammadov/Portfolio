using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Models.DataContext;
using Riodetask.AppCode.Infastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.BlogMolus
{
    public class BlogsRemoveCommand : IRequest<CommandJsonResponse>
    {

        public int? Id { get; set; }


        public class BlogsRemoveCommandHandler : IRequestHandler<BlogsRemoveCommand, CommandJsonResponse>
        {
            readonly ResumeDbContext db;
            public BlogsRemoveCommandHandler(ResumeDbContext db)
            {
                this.db = db;
            }
            public async Task<CommandJsonResponse> Handle(BlogsRemoveCommand request, CancellationToken cancellationToken)
            {

                var response = new CommandJsonResponse();


                if (request.Id == null || request.Id < 1)
                {
                    response.Error = true;
                    response.Message = "Mellumat tamligi qorunmayib";
                    goto end;
                }

                var brand = await db.blogposts.FirstOrDefaultAsync(m => m.ID == request.Id && m.DeleteByUserId == null);

                if (brand == null)
                {
                    response.Error = true;
                    response.Message = "Melumat movcud deyildir.";
                    goto end;
                }

                brand.DeleteByUserId = 1;
                brand.DeletedTime = DateTime.Now;
                await db.SaveChangesAsync(cancellationToken);

                response.Error = false;
                response.Message = "ugurlu elemlyat";
            end:
                return response;
            }

        }

    }

}