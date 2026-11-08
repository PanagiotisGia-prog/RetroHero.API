namespace RetroHero.Api.DTOs
{
    /* 
    A DTO is a contract between the client and server since it represent 
    a shared agreement about how data will be transferred and used.
    */

    public record ReadGamesDTO(int Id, string Name, string Genre, string Platform, decimal Price, DateOnly Release);
}