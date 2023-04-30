using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            builder.Entity<SaveProcess>(entity =>
            {
                entity.ToTable(name: "SaveProcess").HasKey(e => e.Id);
            });

            builder.Entity<SourceLoginAPIModel>(entity =>
            {
                entity.ToTable(name: "SourceLoginAPIModel").HasKey(e => e.Id);
            });

            builder.Entity<SourceDataAPIModel>(entity =>
            {
                entity.ToTable(name: "SourceDataAPIModel").HasKey(e => e.Id);
            });

            builder.Entity<DestinationLoginAPIModel>(entity =>
            {
                entity.ToTable(name: "DestinationLoginAPIModel").HasKey(e => e.Id);
            });

            builder.Entity<DestinationDataAPIModel>(entity =>
            {
                entity.ToTable(name: "DestinationDataAPIModel").HasKey(e => e.Id);
            });
            
            builder.Entity<SaveProceeSettingDetailModel>(entity =>
            {
                entity.ToTable(name: "SaveProceeSettingDetailModel").HasKey(e => e.Id);
            });
        }

        public DbSet<SaveProcess> SaveProcesses { get; set; }
        public DbSet<SourceLoginAPIModel> SourceLoginAPIModels { get; set;}
        public DbSet<SourceDataAPIModel> SourceDataAPIModels { get; set;}
        public DbSet<DestinationLoginAPIModel> DestinationLoginAPIModels { get; set;}
        public DbSet<DestinationDataAPIModel> DestinationDataAPIModels { get; set;}
        public DbSet<SaveProceeSettingDetailModel> SaveProceeSettingDetailModels { get; set;}
    }
}
