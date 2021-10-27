using MediatR;
using Portfolio.WebUI.Model.ViewModels;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.EducationModule
{
    public class ExperiencePagedQuery : IRequest<PagedViewModel<Education>>
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 3;

        public class 
            EducationPagedQueryHandler : IRequestHandler<ExperiencePagedQuery, PagedViewModel<Education>>
        {
            readonly ResumeDbContext db;
            public EducationPagedQueryHandler(ResumeDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<Education>> Handle(ExperiencePagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.Educations.Where(b =>b.DeleteByUserId == null).AsQueryable(); // silinmemisleri getirir

                //int queryCount = await query.CountAsync(cancellationToken); // silinmemislerin sayni takir

                //var pagedData = await query.Skip((model.Pageindex - 1) * model.PageCount) // skip necensi seyfede,
                //    .Take(model.PageCount) // nece denesini gosdersin.
                //    .ToListAsync(cancellationToken);

                return new PagedViewModel<Education>(query, model.pageIndex, model.pageSize);
            }
        }
    }
}