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

namespace Portfolio.WebUI.Appcode.Application.BlogMolus
{

    public class BlogsCreateComman : IRequest<BlogPosts>
    {
        [Required]


        public string Title { get; set; }

        public string BlogType { get; set; }

        public string Body { get; set; }

        public string ImagePati { get; set; }

        public string Description { get; set; }

        public string ShopDescription { get; set; }

        public IFormFile file { get; set; }

        public DateTime? PublishedDate { get; set; }



        public class BlogsCreateCommanHandler : IRequestHandler<BlogsCreateComman, BlogPosts>
        {
            readonly ResumeDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;
            public BlogsCreateCommanHandler(ResumeDbContext db, IActionContextAccessor ctx, IWebHostEnvironment env) //Model.State burda yoxlamaq ucun yazilib.
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<BlogPosts> Handle(BlogsCreateComman model, CancellationToken cancellationToken)
            {


                if (ctx.IsModelStateValid())
                {
                    BlogPosts blog = new BlogPosts();
                    string extension = Path.GetExtension(model.file.FileName);  //.jpg tapmaq ucundur. png .gng 

                    blog.ImagePath = $"{Guid.NewGuid()}{extension}";//imagenin name 


                    string phsicalFileName = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", blog.ImagePath);

                    using (var stream = new FileStream(phsicalFileName, FileMode.Create, FileAccess.Write))
                    {
                        await model.file.CopyToAsync(stream);
                    }

                    blog.PublishDate = DateTime.Now;
                    blog.Title = model.Title;
                    blog.Body = model.Body;
                    blog.BlogType = model.BlogType;
                    blog.Description = model.Description;
                    blog.ShortDescription = model.ShopDescription;


                    db.Add(blog);
                    await db.SaveChangesAsync(cancellationToken);

                    return blog;

                }
                return null;
            }
        }
    }
}