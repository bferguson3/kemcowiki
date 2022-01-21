namespace api.Models
{
    public class Release
    {
        public string Id { get; set; } = string.Empty;
        
        public string LocalizedName { get; set; } = string.Empty;
        public string? RomanizedName { get; set; } = string.Empty;

        public Platform? Platform { get; set; }

        public string? Details { get; set; } = string.Empty;

        public DateTime? ReleaseDate { get; set; }
    }
}