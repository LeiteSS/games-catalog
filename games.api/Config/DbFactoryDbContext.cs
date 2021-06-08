using System;
using games.api.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace games.api.Config
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<GamesDbContext>
    {
        private const string connectionString = "server=localhost;port=3306;database=Games;user=ssl;password=03568799We";

        public GamesDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<GamesDbContext>();
            options.UseMySql(connectionString, new MariaDbServerVersion(new Version(10, 3, 29)));

            GamesDbContext context = new GamesDbContext(options.Options);

            return context;
        }
    }
}