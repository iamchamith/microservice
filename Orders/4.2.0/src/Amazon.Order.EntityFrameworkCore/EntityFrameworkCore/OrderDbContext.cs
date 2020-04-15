using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ety = Amazon.Order.Entities;
namespace Amazon.Order.EntityFrameworkCore
{
    public class OrderDbContext : AbpDbContext
    {
        public DbSet<ety.CustomerInfo> CustomerInfo { get; set; }
        public DbSet<ety.Order> Order { get; set; }
        public DbSet<ety.OrderItem> OrderItem { get; set; }
        public DbSet<ety.Shipping> Shipping { get; set; }
        public DbSet<ety.Payment> Payment { get; set; }  

        public OrderDbContext(DbContextOptions<OrderDbContext> options) 
            : base(options)
        {

        }
    }
}
