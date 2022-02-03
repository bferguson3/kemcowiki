namespace api.Models
{
    public class Game
    {
        public string Id { get; set; } = string.Empty;
        
        public string Title { get; set; } = string.Empty;

        public string? RomanizedTitle { get; set; } = string.Empty;

        public List<DataStub> Releases { get; set; } = new List<DataStub>();

        public List<DataStub>? SharedMechanics { get; set; } = new List<DataStub>();

        public DataStub? Series { get; set; }
        
        public TimeSpan? AveragePlayLength { get; set; }

        public List<DataPoint>? DataPoints { get; set; } = new List<DataPoint>();
        
        public string? BoxArtURL { get; set; } = string.Empty;
    }
}
