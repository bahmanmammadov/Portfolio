using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.PersonallnfoModule
{
    public class PersonallnfoSingleQuery : IRequest<PersonalInfo>
    {
        public int Id { get; set; }


        // nested class clasin icinde class
        public class PersonallnfoSingleQueryHandler : IRequestHandler<PersonallnfoSingleQuery, PersonalInfo>
        {
            readonly ResumeDbContext db;
            public PersonallnfoSingleQueryHandler(ResumeDbContext db)
            {
                this.db = db; //Model
            }
            // qeury servic adlanir;    
            public async Task<PersonalInfo> Handle(PersonallnfoSingleQuery model, CancellationToken cancellationToken)
            {

                
                var blog = await db.PersonalInfos
                   .FirstOrDefaultAsync(m => m.ID == model.Id, cancellationToken);

                return blog;
            }
        }

    }
}