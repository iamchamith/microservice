using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Order.EntityFrameworkCore
{
    public class OrderDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public OrderDbContext(DbContextOptions<OrderDbContext> options) 
            : base(options)
        {

        }
    }
}
