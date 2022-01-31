namespace api.Models
{
    public class Mechanic
    {
        public string Id { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public List<Game> Games { get; set; } = new List<Game>();
    }
}