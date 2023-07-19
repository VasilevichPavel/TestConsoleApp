using Newtonsoft.Json;

namespace TestConsoleApp.Core.Models
{
    public class Repository
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        [JsonProperty("html_url")]
        public string Url { get; set; } = string.Empty;
    }
}
