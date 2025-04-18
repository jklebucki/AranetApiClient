using Microsoft.EntityFrameworkCore;

namespace AranetApiClient.Data.Postgres
{
    public class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

        //public DbSet<Sensor> Sensors { get; set; }
    }
}
