using RetroHero.Api.Data;
using RetroHero.Api.EndPoints;

namespace RetroHero.Api
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddValidation();

            builder.AddRetroHeroDB();

            var app = builder.Build();

            app.MapGamesEndPoints();
            app.MapGenresEndpoints();
            app.MapPlatformsEndpoints();

            app.MigrateDB();

            app.Run();
        }
    }
}