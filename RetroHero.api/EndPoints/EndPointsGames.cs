using Microsoft.EntityFrameworkCore;
using RetroHero.Api.Data;
using RetroHero.Api.DTOs;
using RetroHero.Api.Model;

namespace RetroHero.Api.EndPoints{
    static class EndPointsGames
    {
        const string GameEndpointName = "RetroGame";

        public static void MapGamesEndPoints(this WebApplication app)
        {
            var group = app.MapGroup("/games");

            // GET /games
            group.MapGet("/", async (RetroHeroContext dbContext) => 
            await dbContext.DbGames
                                .Include(game => game.Genre)
                                .Include(game => game.Platform)
                                .Select(game => new ReadGamesDTO(
                                        Id: game.Id,
                                        Name: game.Name,
                                        Genre: game.Genre!.Name,
                                        Platform: game.Platform!.Name,
                                        Price: game.Price,
                                        Release: game.Release
                                )).AsNoTracking()
                                  .ToListAsync()
            );

            // GET /games/id => id is replaced with the current id number of the requested game
            group.MapGet("/{id}", async (int id, RetroHeroContext dbContext) =>
            {
                var game = await dbContext.DbGames.FindAsync(id);

                return game is null ? Results.NotFound() : Results.Ok(new GameDetailsDTO(
                    Id: game.Id, 
                    Name: game.Name,
                    GenreId: game.GenreId,
                    PlatformId: game.PlatformId,
                    Price: game.Price,
                    Release: game.Release
                    ));
            }).WithName(GameEndpointName);

            
            // POST /games
            group.MapPost("/", async (CreateGamesDTO newGame, RetroHeroContext dbContext) =>
            {
                bool genreExists = await dbContext.DbGenre.AnyAsync(genre => genre.Id == newGame.GenreId);
                
                if (!genreExists)
                    return Results.BadRequest("Genre cannot be found!");
                
                
                bool platformExists = await dbContext.DbPlatform.AnyAsync(platform => platform.Id == newGame.PlatformId);

                if (!platformExists)
                    return Results.BadRequest();


                Game game = new() 
                {
                    Name = newGame.Name, 
                    GenreId = newGame.GenreId,
                    PlatformId = newGame.PlatformId,
                    Price = newGame.Price, 
                    Release = newGame.Release
                };

                dbContext.DbGames.Add(game);
                await dbContext.SaveChangesAsync();

                GameDetailsDTO gameDetails = new(
                    Id: game.Id, 
                    Name: game.Name, 
                    GenreId: game.GenreId, 
                    PlatformId: game.PlatformId, 
                    Price: game.Price , 
                    Release: game.Release);

                return Results.CreatedAtRoute(GameEndpointName, new {id = gameDetails.Id}, gameDetails);
            });

            
            // PUT /games/id
            group.MapPut("/{id}", async (int id, UpdateGamesDTO updateGame, RetroHeroContext dbContext) =>
            {
                var existingGame = await dbContext.DbGames.FindAsync(id);

                if (existingGame is null) // This means we weren't able to locate the index of the requested game
                {
                    return Results.NotFound();
                }

                existingGame.Name = updateGame.Name;
                existingGame.GenreId = updateGame.GenreId;
                existingGame.PlatformId = updateGame.PlatformId;
                existingGame.Price = updateGame.Price;
                existingGame.Release = updateGame.Release;

                await dbContext.SaveChangesAsync();
            
                return Results.NoContent();
            });

            
            // DELETE /games/id
            group.MapDelete("/{id}", async (int id, RetroHeroContext dbContext) =>
            {
                await dbContext.DbGames
                                .Where(game => game.Id == id)
                                .ExecuteDeleteAsync();

                return Results.NoContent();
            });
        }

    }
}