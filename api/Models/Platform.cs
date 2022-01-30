namespace api.Models
{
    public class Platform
    {
        public string Id { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;
        
        public List<Game>? Games { get; set; }
    }
}