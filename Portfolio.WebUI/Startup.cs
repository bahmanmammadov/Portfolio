using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portfolio.WebUI.Models.DataContext;

namespace Portfolio.WebUI
{
    public class Startup
    {
        readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddDbContext<ResumeDbContext>(cfg => {

                cfg.UseSqlServer(configuration.GetConnectionString("cString"));
            });
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddRouting(cfg => {

                cfg.LowercaseUrls = true;

            });
            services.AddMediatR(this.GetType().Assembly);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(cfg=> {

            cfg.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=BlogPosts}/{action=Index}/{id?}"
        );
                cfg.MapControllerRoute("default", "{controller=Home}/{action=index}/{id?}");

            });

        }
    }
}
