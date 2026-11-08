using System.ComponentModel.DataAnnotations;

namespace RetroHero.Api.DTOs
{
    // In this record class we don't have an Id parameter because the Id is provided by the server after the resourse is created.
    public record UpdateGamesDTO(
        [Required][StringLength(100)]string Name, 
        [Range(1, int.MaxValue)]int GenreId, 
        [Range(1, int.MaxValue)]int PlatformId, 
        [Range(1, 100)]decimal Price, 
        DateOnly Release
        );
}