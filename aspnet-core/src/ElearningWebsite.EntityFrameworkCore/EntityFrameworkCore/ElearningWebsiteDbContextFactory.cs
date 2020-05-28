using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ElearningWebsite.Configuration;
using ElearningWebsite.Web;

namespace ElearningWebsite.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ElearningWebsiteDbContextFactory : IDesignTimeDbContextFactory<ElearningWebsiteDbContext>
    {
        public ElearningWebsiteDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ElearningWebsiteDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ElearningWebsiteDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ElearningWebsiteConsts.ConnectionStringName));

            return new ElearningWebsiteDbContext(builder.Options);
        }
    }
}
