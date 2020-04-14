using Abp.EntityFrameworkCore;
using Amazon.Items.Entities;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Items.EntityFrameworkCore
{
    public class ItemsDbContext : AbpDbContext
    {
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Item> Item { get; set; }
        public ItemsDbContext(DbContextOptions<ItemsDbContext> options) 
            : base(options)
        {

        }
    }
}
