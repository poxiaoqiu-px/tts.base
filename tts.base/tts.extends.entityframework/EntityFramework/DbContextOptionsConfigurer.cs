using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace tts.extends.entityframework
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure<TDbContext>(
             this DbContextOptionsBuilder<TDbContext> dbContextOptions,
            string connectionString
        ) where TDbContext : DbContext
        {
            dbContextOptions.UseMySql(connectionString);
        }

        public static void Configure<TDbContext>(
            this DbContextOptionsBuilder<TDbContext> dbContextOptions,
            DbConnection connection
        ) where TDbContext : DbContext
        {
            dbContextOptions.UseMySql(connection);
        }
    }
}
