using Amazon.Items.Configuration;
using Amazon.Items.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Amazon.Items.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class ItemsDbContextFactory : IDesignTimeDbContextFactory<ItemsDbContext>
    {
        public ItemsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ItemsDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(ItemsConsts.ConnectionStringName)
            );

            return new ItemsDbContext(builder.Options);
        }
    }
}