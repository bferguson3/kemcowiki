namespace api.Models
{
    public class Developer
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? RomanizedName { get; set; } = string.Empty;

        public DateTime? YearsActiveStart { get; set; }
        
        public DateTime? YearsActiveEnd { get; set; }

        public List<DataStub> Staff { get; set; } = new List<DataStub>();

        public List<DataStub> Games { get; set; } = new List<DataStub>();
        
    }
}