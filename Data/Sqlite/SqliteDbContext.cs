using Microsoft.EntityFrameworkCore;

namespace AranetApiClient.Data.Sqlite
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options) { }

        //public DbSet<LogEntry> LogEntries { get; set; }
    }
}
