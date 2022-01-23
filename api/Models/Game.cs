using api.Interfaces;

namespace api.Models
{
    public class Game : IDataModel
    {
        public string Id { get; set; } = string.Empty;
        
        public string Title { get; set; } = string.Empty;
        public string? RomanizedTitle { get; set; } = string.Empty;

        public List<Release>? Releases { get; set; }

        public List<Mechanic>? SharedMechanics { get; set; }

        public GameSeries? Series { get; set; }
        
        public TimeSpan? AveragePlayLength { get; set; }
    }
}