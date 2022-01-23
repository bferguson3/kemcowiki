using api.Interfaces;

namespace api.Models
{
    public class Track : IDataModel
    {
        public string Id { get; set; } = string.Empty;
        
        public string TrackTitle { get; set; } = string.Empty;

        public OST? OST { get; set; }

        public int? TrackNo { get; set; } = 0;
        public TimeSpan? AveragePlayLength { get; set; }

        public string? Lyrics { get; set; } = string.Empty;
    }
}