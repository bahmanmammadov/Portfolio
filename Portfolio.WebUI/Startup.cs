using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortFfoliodetask.Model.Memberships;
using Portfolio.WebUI.Models.DataContext;
using System;

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

            services.AddControllersWithViews(cfg=> {

                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));

            });
            services.AddDbContext<ResumeDbContext>(cfg => {

                cfg.UseSqlServer(configuration.GetConnectionString("cString"));
            });
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddRouting(cfg => {

                cfg.LowercaseUrls = true;

            });
            services.AddMediatR(this.GetType().Assembly);
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddIdentity<PortfolioUser, PortfolioRole>()
                .AddEntityFrameworkStores<ResumeDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<UserManager<PortfolioUser>>();
            services.AddScoped<SignInManager<PortfolioUser>>();
            services.AddScoped<RoleManager<PortfolioRole>>();
            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequiredUniqueChars = 1;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequiredLength = 3;


                cfg.User.RequireUniqueEmail = true;
                //cfg.User.AllowedUserNameCharacters = "";
                cfg.Lockout.MaxFailedAccessAttempts = 3;
                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 3, 0);
            });
            services.ConfigureApplicationCookie(cfg =>
            {
                cfg.AccessDeniedPath = "/accessdenied.html";
                cfg.LoginPath = "/signin.html";
                cfg.ExpireTimeSpan = new TimeSpan(0, 5, 0);
                cfg.Cookie.Name = "Portfolio";
            });

            services.AddAuthentication();
            services.AddAuthorization();

        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           // app.SeedMembership();

            app.UseRouting();
            app.Use(async (context, next) =>
            {
                if (!context.Request.Cookies.ContainsKey("portfolio") &&
                context.Request.RouteValues.TryGetValue("area", out object areaName)
                && areaName.ToString().ToLower().Equals("admin"))
                {
                    var attr = context.GetEndpoint().Metadata.GetMetadata<AllowAnonymousAttribute>();
                    if (attr == null)
                    {
                        //context.Request.Path = "/admin/signin.html";
                        context.Response.Redirect("/admin/signin.html");
                        await context.Response.CompleteAsync();
                    }

                }
                await next();
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(cfg=> {

            cfg.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=bio}/{action=Index}/{id?}"
        );
                cfg.MapControllerRoute("admin", "admin/signin.html",
                   defaults: new
                   {
                       controller = "Account",
                       action = "signin",
                       area = "Admin"
                   });
                cfg.MapControllerRoute("logout.html", "admin/logout.html",
                    defaults: new
                    {
                        controller = "Account",
                        action = "logout",
                        area = "Admin"
                    });
                cfg.MapControllerRoute("x", "signin.html",
                    defaults: new
                    {
                        controller = "Account",
                        action = "signin",
                        area = ""
                    });
                cfg.MapControllerRoute("x", "register.html",
                    defaults: new
                    {
                        controller = "Account",
                        action = "register",
                        area = ""
                    });

                cfg.MapControllerRoute("default", "{controller=Home}/{action=index}/{id?}");

            });

        }
    }
}
