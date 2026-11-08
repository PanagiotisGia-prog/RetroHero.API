namespace RetroHero.Api.DTOs
{
    public record GameDetailsDTO(int Id, string Name, int GenreId, int PlatformId, decimal Price, DateOnly Release);
}