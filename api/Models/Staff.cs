namespace api.Models
{
    public class Staff
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        
        public string? RomanizedName { get; set; } = string.Empty;

        public Developer? WorksFor { get; set; }

        public List<DataStub> CreditedOn { get; set; } = new List<DataStub>();

        public DateTime? YearsActiveStart { get; set; }

        public DateTime? YearsActiveEnd { get; set; }
    }
}