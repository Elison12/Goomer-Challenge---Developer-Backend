﻿using GoomerChallenger.Domain.Models;
using GoomerChallenger.Notification.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoomerChallenger.Infra.Data.Context
{
    public class GoomerContext : DbContext
    {
        public GoomerContext()
        {
        }
        public GoomerContext(DbContextOptions<GoomerContext> options) : base(options) { }


        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cardapio> cardapio { get; set; }
        public DbSet<Prato> Prato   { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Entity>();
            modelBuilder.HasDefaultSchema("GoomerContext");
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoomerContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
