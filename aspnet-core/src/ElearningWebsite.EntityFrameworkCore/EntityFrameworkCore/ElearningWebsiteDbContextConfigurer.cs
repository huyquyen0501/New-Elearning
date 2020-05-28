using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ElearningWebsite.EntityFrameworkCore
{
    public static class ElearningWebsiteDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ElearningWebsiteDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ElearningWebsiteDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
