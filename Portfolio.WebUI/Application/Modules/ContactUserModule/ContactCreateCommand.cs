using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Portfolio.WebUI.AppCode.Extension;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using Riodetask.AppCode.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Application.Modules.ContactUserModule
{
    public class ContactCreateCommand : IRequest<CommandJsonResponse>
    {
        public string Email { get; set; }
        public string Comment { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public class ContactCreateCommandHandler : IRequestHandler<ContactCreateCommand, CommandJsonResponse>
        {
            readonly ResumeDbContext db;
            readonly IActionContextAccessor ctx;

            public ContactCreateCommandHandler(ResumeDbContext db , IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;


            }
            public async Task<CommandJsonResponse> Handle(ContactCreateCommand request, CancellationToken cancellationToken)
            {
                var response = new CommandJsonResponse();
                if (ctx.IsModelStateValid())
                {
                    var contact = new Contact();
                    request.Email = contact.Email;
                    request.Subject = contact.Subject;
                    request.Content = contact.Content;
                    request.Comment = contact.Comment;
                    db.Add(request);
                    await db.SaveChangesAsync(cancellationToken);
                    response.Error = false;
                    response.Message = "Ugurlu";
                    return response;
                }

                response.Error = true;
                response.Message = "Yeniden sina";
                return response;



            }


        }
    }
}
