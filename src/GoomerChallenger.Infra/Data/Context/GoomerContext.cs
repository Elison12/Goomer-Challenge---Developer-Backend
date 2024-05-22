using GoomerChallenger.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GoomerChallenger.Infra.Data.Context
{
    public class GoomerContext : DbContext
    {
        public GoomerContext(DbContextOptions<GoomerContext> options) : base(options)
        {
        }

        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoomerContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
