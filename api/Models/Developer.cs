
using api.Interfaces;

namespace api.Models
{
    public class Developer : IDataModel
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string? RomanizedName { get; set; } = string.Empty;

        public List<Employee>? Employees { get; set; }

        public DateTime? YearsActiveStart { get; set; }
        public DateTime? YearsActiveEnd { get; set; }

        public List<Game> GamesList { get; set; } = new List<Game>();
        
    }
}