namespace api.Models
{
    public class Game
    {
        public string Title { get; set; } = string.Empty;

        public DateTime? OriginalReleaseDate { get; set; }

        public TimeSpan? AveragePlayLength { get; set; }
    }
}