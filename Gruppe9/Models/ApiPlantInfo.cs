using System.Text.Json.Serialization;

namespace Gruppe9.Models
{
    // Representerer én plante fra API-responsen
    public class ApiPlantInfo
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; } // Intern kode for planten (f.eks. "BIRCH")

        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; } // Navn på plante (f.eks. "Birch")

        [JsonPropertyName("indexInfo")]
        public ApiIndexInfo? IndexInfo { get; set; } // Pollenindeksdata for planten 
    }
}
