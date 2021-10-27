using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.EducationModule
{
    public class EducationSingleQuery : IRequest<Education>
    {
        public int Id { get; set; }


        // nested class clasin icinde class
        public class EducationSingleQueryHandler : IRequestHandler<EducationSingleQuery, Education>
        {
            readonly ResumeDbContext db;
            public EducationSingleQueryHandler(ResumeDbContext db)
            {
                this.db = db; //Model
            }
            // qeury servic adlanir;    
            public async Task<Education> Handle(EducationSingleQuery model, CancellationToken cancellationToken)
            {

                
                var blog = await db.Educations
                   .FirstOrDefaultAsync(m => m.ID == model.Id, cancellationToken);

                return blog;
            }
        }

    }
}