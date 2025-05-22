using System.Text.Json.Serialization;
using Gruppe9.Converters;

namespace Gruppe9.Models
{
    // Representerer hovedobjektet fra API-responsen
    public class ApiPollenResponse
    {
        [JsonPropertyName("dailyInfo")]
        public List<ApiDateInfo> DailyInfo { get; set; } = new(); // Liste over daglige pollenverdier
    }

    // Representerer data for én enkelt dag i API-responsen
    public class ApiDateInfo
    {
        [JsonPropertyName("date")]
        [JsonConverter(typeof(DateOnlyConverter))]
        public string? Date { get; set; } // Dato i format YYYY-MM-DD

        [JsonPropertyName("plantInfo")]
        public List<ApiPlantInfo>? PlantInfo { get; set; } = new(); // Liste over planter og tilhørende indekser
    }

    // Representerer pollenindeksinformasjon for en plante
    public class ApiIndexInfo
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; } // Kode for indekskategori

        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; } // Navn på indekskategori

        [JsonPropertyName("value")]
        public int Value { get; set; } // Verdi på pollenindeks

        [JsonPropertyName("category")]
        public string? Category { get; set; } // Kategori (f.eks. "Low", "High")

        [JsonPropertyName("indexDescription")]
        public string? IndexDescription { get; set; } // Beskrivelse av indeksen
    }
}
