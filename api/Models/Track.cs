namespace api.Models
{
    public class Track
    {
        public string Id { get; set; } = string.Empty;
        
        public string TrackTitle { get; set; } = string.Empty;

        public int TrackNo { get; set; } = 0;

        public TimeSpan? AveragePlayLength { get; set; }

        public string Lyrics { get; set; } = string.Empty;
    }
}