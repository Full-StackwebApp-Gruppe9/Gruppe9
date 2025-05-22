using System.Text.Json;
using Gruppe9.Models;
using System.Text;

namespace Gruppe9.Services
{
    public class PollenAPIService : IPollenAPIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "AIzaSyCcJ3vf6FXeMkfgdGuJytfRuh6PQ_tDJ7U";
        private readonly string _baseUrl = "https://pollen.googleapis.com/v1/forecast:lookup";

        public PollenAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiPollenResponse?> HentPollenDataAsync()
        {
            //Tønsberg
            string url = $"{_baseUrl}?location.latitude=59.26754&location.longitude=10.40762&days=5&key={_apiKey}";

            //New York
            //string url = $"{_baseUrl}?location.latitude=40.7128&location.longitude=-74.0060&days=5&key={_apiKey}";

            //Karleby, Finland
            //string url = $"{_baseUrl}?location.latitude=59.26754&location.longitude=10.40762&days=5&key={_apiKey}";


            try
            {
                Console.WriteLine($"🌍 Henter pollen-data fra URL: {url}");

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                Console.WriteLine("📥 API-respons mottatt:");
                Console.WriteLine(json); // Logg hele JSON-strengen

                // Deserialiser fra JSON-streng (ikke stream) for enkel feilsøking
                using var contentStream = new MemoryStream(Encoding.UTF8.GetBytes(json));

                var pollenResponse = await JsonSerializer.DeserializeAsync<ApiPollenResponse>(
                    contentStream,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (pollenResponse == null)
                {
                    Console.WriteLine("⚠️ Deserialisering returnerte null.");
                }
                else
                {
                    Console.WriteLine($"✅ Antall dager mottatt: {pollenResponse.DailyInfo.Count}");
                }

                return pollenResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Feil under API-kall eller parsing: {ex.Message}");
                return null;
            }
        }
    }
}
