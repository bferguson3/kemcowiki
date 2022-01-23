using api.Interfaces;

namespace api.Models
{
    public class OST : IDataModel
    {
        public string Id { get; set; } = string.Empty;
        
        public string Title { get; set; } = string.Empty;
        
        public Game Game { get; set; }

        public List<Track> TrackList { get; set; }
        
        public List<Employee> Composers { get; set; }
    }
}