using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.BioModule
{
    public class BioSingleQuery : IRequest<Bio>
    {
        // bu hisse query model adlanir;(axtaris zamani bura lazim olur)
        public int Id { get; set; }


        // nested class clasin icinde class
        public class BioSingleQueryHandler : IRequestHandler<BioSingleQuery, Bio>
        {
            readonly ResumeDbContext db;
            public BioSingleQueryHandler(ResumeDbContext db)
            {
                this.db = db; //Model
            }
            // qeury servic adlanir;    
            public async Task<Bio> Handle(BioSingleQuery model, CancellationToken cancellationToken)
            {

                
                var blog = await db.Bios
                   .FirstOrDefaultAsync(m => m.ID == model.Id, cancellationToken);

                return blog;
            }
        }

    }
}