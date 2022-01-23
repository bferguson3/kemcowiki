using api.Interfaces;

namespace api.Models
{
    public class Mechanic : IDataModel
    {
        public string Id { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public List<Game>? GamesUsed { get; set; }
    }
}