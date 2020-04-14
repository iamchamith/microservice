using Microsoft.EntityFrameworkCore;

namespace Amazon.Items.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<ItemsDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for ItemsDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
