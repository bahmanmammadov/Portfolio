using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Models.Entity;
using PortFfoliodetask.Model.Memberships;

namespace Portfolio.WebUI.Models.DataContext
{
    public class ResumeDbContext : IdentityDbContext<PortfolioUser, PortfolioRole, int, PortfolioUserClaim, PortfolioUserRole, PortfolioUserLogin, PortfolioRoleClaim, PortfolioUserToken>
    {
        public ResumeDbContext()
            : base()
        {

        }
        public ResumeDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<BlogPosts> blogposts { get; set; }
        public DbSet<Project> portfolio { get; set; }
        public DbSet<Experience> experiences { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Skills> Skillss { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Icons> Icons { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<Project> Projects { get; set; }










        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PortfolioUser>(e =>
            {
                e.ToTable("User", "Membership");
            });
            builder.Entity<PortfolioRole>(e =>
            {
                e.ToTable("Role", "Membership");
            });
            builder.Entity<PortfolioRoleClaim>(e =>
            {
                e.ToTable("RoleClaim", "Membership");
            });
            builder.Entity<PortfolioUserClaim>(e =>
            {
                e.ToTable("UserClaim", "Membership");
            });
            builder.Entity<PortfolioUserLogin>(e =>
            {
                e.HasKey(p => new { p.ProviderKey, p.LoginProvider });

                e.ToTable("UserLogin", "Membership");
            });
            builder.Entity<PortfolioUserToken>(e =>
            {
                e.ToTable("UserToken", "Membership");
            });
            builder.Entity<PortfolioUserRole>(e =>
            {
                e.ToTable("UserRole", "Membership");
            });
        }


    }
}
