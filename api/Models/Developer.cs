
namespace api.Models
{
    public class Developer
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string? RomanizedName { get; set; } = string.Empty;

        public Employee[]? Credits { get; set; }

        public DateTime? YearsActiveStart { get; set; }
        public DateTime? YearsActiveEnd { get; set; }

        public List<Game> GamesCreated { get; set; } = new List<Game>();
        
    }
}