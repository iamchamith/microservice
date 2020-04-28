using Identity.Model.Entities;
using Identity.Utility;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Identity.Model.ViewModel;

namespace Identity.Model.Infastructure
{
    public class IdentityContext: IdentityDbContext
    {
        public DbSet<UserInfo> UserInfo { get; set; }
        public IdentityContext(DbContextOptions<IdentityContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(AppConst.DEFAULT_SCHEMA);
            modelBuilder.Entity<UserInfo>().OwnsOne(c => c.Address);
            modelBuilder.Entity<UserInfo>().OwnsOne(c => c.Name);
        }
    }
}
