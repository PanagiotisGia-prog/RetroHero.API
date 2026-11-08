using Microsoft.EntityFrameworkCore;
using RetroHero.Api.Data;
using RetroHero.Api.DTOs;

namespace RetroHero.Api.EndPoints
{
    static class EndPointsPlatforms
    {
        public static void MapPlatformsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/platforms");

            // GET /platforms
            group.MapGet("/", async (RetroHeroContext dbContext) 
                                    => await dbContext.DbPlatform
                                                        .Select(platform => new ReadPlatformsDTO(Id: platform.Id, Name: platform.Name))
                                                        .ToListAsync()
            );
        }
    }
}