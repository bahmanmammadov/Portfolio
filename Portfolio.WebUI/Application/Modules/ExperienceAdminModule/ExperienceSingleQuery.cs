using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.ExperienceModule
{
    public class ExperienceSingleQuery : IRequest<Experience>
    {
        public int Id { get; set; }


        // nested class clasin icinde class
        public class ExperienceSingleQueryHandler : IRequestHandler<ExperienceSingleQuery, Experience>
        {
            readonly ResumeDbContext db;
            public ExperienceSingleQueryHandler(ResumeDbContext db)
            {
                this.db = db; //Model
            }
            // qeury servic adlanir;    
            public async Task<Experience> Handle(ExperienceSingleQuery model, CancellationToken cancellationToken)
            {

                
                var blog = await db.experiences
                   .FirstOrDefaultAsync(m => m.ID == model.Id, cancellationToken);

                return blog;
            }
        }

    }
}