using Microsoft.EntityFrameworkCore;
using RetroHero.Api.Data;
using RetroHero.Api.DTOs;

namespace RetroHero.Api.EndPoints
{
    static class EndPointsGenres
    {
        public static void MapGenresEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/genres");

            // GET /genres
            group.MapGet("/", async (RetroHeroContext dbContext) 
                                        => await dbContext.DbGenre
                                            .Select(genre => new ReadGenresDTO(Id: genre.Id, Name: genre.Name))
                                            .ToListAsync()
            );
        }
    }
}