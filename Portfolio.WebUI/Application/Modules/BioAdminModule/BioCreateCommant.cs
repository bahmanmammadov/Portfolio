using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Portfolio.WebUI.AppCode.Extension;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.BioModule
{

    public class BioCreateComman : IRequest<Bio>
    {
        [Required]

        public string Content { get; set; }

        public DateTime? PublishedDate { get; set; }



        public class BioCreateCommanHandler : IRequestHandler<BioCreateComman, Bio>
        {
            readonly ResumeDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;
            public BioCreateCommanHandler(ResumeDbContext db, IActionContextAccessor ctx, IWebHostEnvironment env) //Model.State burda yoxlamaq ucun yazilib.
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<Bio> Handle(BioCreateComman model, CancellationToken cancellationToken)
            {


                if (ctx.IsModelStateValid())
                {
                    Bio bio = new Bio();
                    bio.Content = model.Content;
                    db.Bios.Add(bio);
                    await db.SaveChangesAsync(cancellationToken);
                    return bio;
                }
                return null;
            }
        }
    }
}