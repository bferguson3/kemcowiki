namespace api.Models
{
    public class OST
    {
        public string Id { get; set; } = string.Empty;
        
        public string Title { get; set; } = string.Empty;
        
        public Game? Game { get; set; }

        public List<Track> TrackList { get; set; } = new List<Track>();
        
        public List<DataStub> Composers { get; set; } = new List<DataStub>();
    }
}