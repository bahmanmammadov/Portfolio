using MediatR;
using Portfolio.WebUI.Model.ViewModels;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.ExperienceModule
{
    public class ExperiencePagedQuery : IRequest<PagedViewModel<Experience>>
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 3;

        public class 
            ExperiencePagedQueryHandler : IRequestHandler<ExperiencePagedQuery, PagedViewModel<Experience>>
        {
            readonly ResumeDbContext db;
            public ExperiencePagedQueryHandler(ResumeDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<Experience>> Handle(ExperiencePagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.experiences.Where(b =>b.DeleteByUserId == null).AsQueryable(); // silinmemisleri getirir

                //int queryCount = await query.CountAsync(cancellationToken); // silinmemislerin sayni takir

                //var pagedData = await query.Skip((model.Pageindex - 1) * model.PageCount) // skip necensi seyfede,
                //    .Take(model.PageCount) // nece denesini gosdersin.
                //    .ToListAsync(cancellationToken);

                return new PagedViewModel<Experience>(query, model.pageIndex, model.pageSize);
            }
        }
    }
}