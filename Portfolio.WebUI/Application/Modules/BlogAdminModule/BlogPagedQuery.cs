using MediatR;
using Portfolio.WebUI.Model.ViewModels;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.BlogMolus
{
    public class BlogPagedQuery : IRequest<PagedViewModel<BlogPosts>>
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 3;

        public class BlogPagedQueryHandler : IRequestHandler<BlogPagedQuery, PagedViewModel<BlogPosts>>
        {
            readonly ResumeDbContext db;
            public BlogPagedQueryHandler(ResumeDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<BlogPosts>> Handle(BlogPagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.blogposts.Where(b =>b.DeleteByUserId == null).AsQueryable(); // silinmemisleri getirir

                //int queryCount = await query.CountAsync(cancellationToken); // silinmemislerin sayni takir

                //var pagedData = await query.Skip((model.Pageindex - 1) * model.PageCount) // skip necensi seyfede,
                //    .Take(model.PageCount) // nece denesini gosdersin.
                //    .ToListAsync(cancellationToken);

                return new PagedViewModel<BlogPosts>(query, model.pageIndex, model.pageSize);
            }
        }
    }
}