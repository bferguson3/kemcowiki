namespace api.Models 
{
    public class Employee 
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string? RomanizedName { get; set; } = string.Empty;

        public Developer? WorksFor { get; set; }

        public List<Game> GamesCreated { get; set; } = new List<Game>();
    }
}