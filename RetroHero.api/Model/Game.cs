namespace RetroHero.Api.Model
{
    class Game
    {
        public int Id { get; set; }

        public required string Name { get ; set; }

        public GameGenre? Genre { get; set; }
        
        public int GenreId { get; set; }

        public GamePlatform? Platform { get; set; }

        public int PlatformId { get; set; }

        public decimal Price { get; set; }
    
        public DateOnly Release { get; set; }
    }
}