using MediatR;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Models.DataContext;
using Portfolio.WebUI.Models.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Appcode.Application.BlogMolus
{
    public class BlogSingleQuery : IRequest<BlogPosts>
    {
        // bu hisse query model adlanir;(axtaris zamani bura lazim olur)
        public int Id { get; set; }


        // nested class clasin icinde class
        public class BlogSingleQueryHandler : IRequestHandler<BlogSingleQuery, BlogPosts>
        {
            readonly ResumeDbContext db;
            public BlogSingleQueryHandler(ResumeDbContext db)
            {
                this.db = db; //Model
            }
            // qeury servic adlanir;    
            public async Task<BlogPosts> Handle(BlogSingleQuery model, CancellationToken cancellationToken)
            {

                if (model.Id <= 0)
                {
                    return null;
                }
                var blog = await db.blogposts
                   .FirstOrDefaultAsync(m => m.ID == model.Id, cancellationToken);

                return blog;
            }
        }

    }
}