using Microsoft.EntityFrameworkCore;
using WhereIsMyFleet.Core.Features.Fleet;

namespace WhereIsMyFleet.Core
{
    public class WhereIsMyFleetDbContext : DbContext
    {
        private readonly string _connectionString;

        public WhereIsMyFleetDbContext()
        {

        }

        public WhereIsMyFleetDbContext(DbContextOptions<WhereIsMyFleetDbContext> options) : base(options)
        {

        }

        public WhereIsMyFleetDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Drone> Drones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
