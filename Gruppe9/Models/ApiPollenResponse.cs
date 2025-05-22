using System.Text.Json.Serialization;
using Gruppe9.Converters;

namespace Gruppe9.Models
{
    public class ApiPollenResponse
    {
        [JsonPropertyName("dailyInfo")]
        public List<ApiDateInfo> DailyInfo { get; set; } = new();
    }

    public class ApiDateInfo
    {
        [JsonPropertyName("date")]
        [JsonConverter(typeof(DateOnlyConverter))]
        public string? Date { get; set; }

        [JsonPropertyName("plantInfo")]
        public List<ApiPlantInfo>? PlantInfo { get; set; } = new();
    }

    public class ApiIndexInfo
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("indexDescription")]
        public string? IndexDescription { get; set; }
    }
}
