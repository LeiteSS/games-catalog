using games.api.Business.Entities;
using games.api.Infraestructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace games.api.Infraestructure.Data
{
    public class GamesDbContext : DbContext
    {
        public GamesDbContext(DbContextOptions<GamesDbContext> options) :base(options)
         {
             
         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameMapping());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Game> Game { get; set; }
    }
}