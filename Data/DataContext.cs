using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ultimate_Tic_Tac_Toe.Models;

namespace Ultimate_Tic_Tac_Toe.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<Games> Games { get; set; }

        public DbSet<LocalBoard> LocalBoard { get; set; }

        public DbSet<MainBoard> MainBoard { get; set; }

        public DbSet<Players> Players { get; set; }
    }
}
