namespace api.Models
{
    public class Game
    {
        public string Id { get; set; } = string.Empty;
        
        public string Title { get; set; } = string.Empty;

        public DateTime? OriginalReleaseDate { get; set; }

        public TimeSpan? AveragePlayLength { get; set; }
    }
}