namespace api.Models
{
    public class DataPoint
    {
        //public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Format("<h2>Paragraph Title</h2>");

        public string Text { get; set; } = string.Format("<p>Paragraph text</p>");
    }
}