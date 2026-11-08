using Microsoft.EntityFrameworkCore;
using RetroHero.Api.Model;

namespace RetroHero.Api.Data
{
    class RetroHeroContext(DbContextOptions<RetroHeroContext> options) : DbContext(options)
    {
        // Each DbSet represents one table. The table name comes from the property name.
        public DbSet<Game> DbGames => Set<Game>();

        public DbSet<GameGenre> DbGenre => Set<GameGenre>();

        public DbSet<GamePlatform> DbPlatform => Set<GamePlatform>();
    }
}