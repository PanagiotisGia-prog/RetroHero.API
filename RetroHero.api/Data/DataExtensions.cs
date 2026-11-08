using Microsoft.EntityFrameworkCore;
using RetroHero.Api.Model;

namespace RetroHero.Api.Data
{
    static class DataExtensions
    {
        // Applies any pending migrations. This also triggers the seeding.
        public static void MigrateDB(this WebApplication app)
        {
            /* The DbContext is Scoped (one per HTTP request), but at startup there is no
            request. We create a scope manually so we can resolve it. */
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider
                                 .GetRequiredService<RetroHeroContext>();
            dbContext.Database.Migrate();
        }

        public static void AddRetroHeroDB(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("RetroHero");

            /*  
                DbContext has a Scoped service lifetime because:
                1. It ensures that a new instance of DbContext is created per request
                2. DB Connections are limited expensive resourse
                3. DbContext is not thread-safe. Scoped avoids concurrencyt issues
                4. Makes it easier to manage transactions and ensures data consistency
                5. Reusing a DbContext instance can lead an increased memory usage 
            */

            builder.Services.AddSqlite<RetroHeroContext>(
                connectionString: connectionString,

                // UseSeeding runs when the migrations are applied.
                optionsAction: options => options.UseSeeding((dbContext, _) => 
                {   
                    // Only insert when the table is empty, so restarting the app never creates duplicates.
                    if (!dbContext.Set<GameGenre>().Any())
                    {
                        dbContext.Set<GameGenre>().AddRange(
                            new GameGenre { Name = "Action" },
                            new GameGenre { Name = "Action Adventure" },
                            new GameGenre { Name = "Action Platformer" },
                            new GameGenre { Name = "Adventure" },
                            new GameGenre { Name = "Adventure Platformer" },
                            new GameGenre { Name = "Fighting" },
                            new GameGenre { Name = "FPS" },
                            new GameGenre { Name = "Horror" },
                            new GameGenre { Name = "Platformer" },
                            new GameGenre { Name = "Racing" },
                            new GameGenre { Name = "RPG" },
                            new GameGenre { Name = "RTS" },
                            new GameGenre { Name = "Sport" },
                            new GameGenre { Name = "Survival" },
                            new GameGenre { Name = "Survival Horror" }
                        );

                        dbContext.SaveChanges();
                    }

                    if (!dbContext.Set<GamePlatform>().Any())
                    {
                        dbContext.Set<GamePlatform>().AddRange(
                            new GamePlatform { Name = "MS-DOS" },
                            new GamePlatform { Name = "NES"},
                            new GamePlatform { Name = "PS1"},
                            new GamePlatform { Name = "Sega Genesis"},
                            new GamePlatform { Name = "XBOX"}
                        );

                        dbContext.SaveChanges();
                    }
                })
            );
        }
    }
}