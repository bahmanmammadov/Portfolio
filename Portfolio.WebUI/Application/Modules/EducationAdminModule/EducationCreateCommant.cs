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

namespace Portfolio.WebUI.Appcode.Application.EducationModule
{

    public class EducationCreateComman : IRequest<Education>
    {
        public string TimeInterval { get; set; }
        public string Occuption { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string LinkForDiplom { get; set; }



        public class EducationCreateCommanHandler : IRequestHandler<EducationCreateComman, Education>
        {
            readonly ResumeDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;
            public EducationCreateCommanHandler(ResumeDbContext db, IActionContextAccessor ctx, IWebHostEnvironment env) //Model.State burda yoxlamaq ucun yazilib.
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<Education> Handle(EducationCreateComman model, CancellationToken cancellationToken)
            {


                if (ctx.IsModelStateValid())
                {
                    Education bio = new Education();
                    bio.TimeInterval = model.TimeInterval;
                    bio.Occuption = model.Occuption;
                    bio.CompanyName = model.CompanyName;
                    bio.Location = model.Location;
                    bio.LinkForDiplom = model.LinkForDiplom;


                    db.Educations.Add(bio);
                    await db.SaveChangesAsync(cancellationToken);
                    return bio;
                }
                return null;
            }
        }
    }
}