using Microsoft.EntityFrameworkCore;

namespace Amazon.Order.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<OrderDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for OrderDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
