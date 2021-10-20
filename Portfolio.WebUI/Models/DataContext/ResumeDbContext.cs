using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Models.Entity;

namespace Portfolio.WebUI.Models.DataContext
{
    public class ResumeDbContext : DbContext
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

        







        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<RiodeUser>(e =>
        //    {
        //        e.ToTable("User", "Membership");
        //    });
        //    builder.Entity<RiodeRole>(e =>
        //    {
        //        e.ToTable("Role", "Membership");
        //    });
        //    builder.Entity<RiodeRoleClaim>(e =>
        //    {
        //        e.ToTable("RoleClaim", "Membership");
        //    });
        //    builder.Entity<RiodeUserClaim>(e =>
        //    {
        //        e.ToTable("UserClaim", "Membership");
        //    });
        //    builder.Entity<RiodeUserLogin>(e =>
        //    {
        //        e.HasKey(p => new { p.ProviderKey, p.LoginProvider });

        //        e.ToTable("UserLogin", "Membership");
        //    });
        //    builder.Entity<RiodeUserToken>(e =>
        //    {
        //        e.ToTable("UserToken", "Membership");
        //    });
        //    builder.Entity<RiodeUserRole>(e =>
        //    {
        //        e.ToTable("UserRole", "Membership");
        //    });
        //}


    }
}
