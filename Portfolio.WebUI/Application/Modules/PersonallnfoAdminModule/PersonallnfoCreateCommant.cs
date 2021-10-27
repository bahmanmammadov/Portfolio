using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Portfolio.WebUI.AppCode.Extension;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.PersonallnfoModule
{

    public class PersonallnfoCreateComman : IRequest<PersonalInfo>
    {
        public string Location { get; set; }
        public string Degree { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string CareerLevel { get; set; }
        public int Fax { get; set; }
        public string Website { get; set; }




        public class PersonallnfoCreateCommanHandler : IRequestHandler<PersonallnfoCreateComman, PersonalInfo>
        {
            readonly ResumeDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;
            public PersonallnfoCreateCommanHandler(ResumeDbContext db, IActionContextAccessor ctx, IWebHostEnvironment env) //Model.State burda yoxlamaq ucun yazilib.
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<PersonalInfo> Handle(PersonallnfoCreateComman model, CancellationToken cancellationToken)
            {


                if (ctx.IsModelStateValid())
                {
                    PersonalInfo bio = new PersonalInfo();

                    bio.Location = model.Location;
                    bio.Degree = model.Degree;
                    bio.PhoneNumber = model.PhoneNumber;
                    bio.Email = model.Email;
                    bio.Experience = model.Experience;
                    bio.CareerLevel = model.CareerLevel;
                    bio.Fax = model.Fax;
                    bio.Website = model.Website;


                    db.PersonalInfos.Add(bio);
                    await db.SaveChangesAsync(cancellationToken);
                    return bio;
                }
                return null;
            }
        }
    }
}