using api.Interfaces;

namespace api.Settings
{
    public class ApiSettings : IApiSettings
    {
        public string DatabaseName { get; set; } = string.Empty;
    }
}