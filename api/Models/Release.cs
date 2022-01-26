using api.Interfaces;

namespace api.Models
{
    public class Release : IDataModel
    {
        public string Id { get; set; } = string.Empty;
        
        public string Name { get; set; } = string.Empty;            // General name used interally
        public string? LocalizedName { get; set; } = string.Empty;  // (unicode) Name specific to the locale
        public string? RomanizedName { get; set; } = string.Empty;  // Romanization, if available

        public Platform? Platform { get; set; }

        public string? Details { get; set; } = string.Empty;

        public DateTime? ReleaseDate { get; set; }
        public DateTime? DigitalDistributionEndDate { get; set; } // digital only
    }
}