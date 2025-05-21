using System.Text.Json.Serialization;

namespace Gruppe9.Models
{
    public class ApiPlantInfo
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("indexInfo")]
        public ApiIndexInfo? IndexInfo { get; set; } // dette er ny struktur
    }
}
