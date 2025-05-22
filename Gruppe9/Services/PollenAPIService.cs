using System.Text.Json;
using Gruppe9.Models;
using System.Text;

namespace Gruppe9.Services
{
    // Implementerer tjenesten som henter og deserialiserer pollendata fra Google Pollen API
    public class PollenAPIService : IPollenAPIService
    {
        private readonly HttpClient _httpClient; // HTTP-klient for å sende forespørsler
        private readonly string _apiKey = "AIzaSyCcJ3vf6FXeMkfgdGuJytfRuh6PQ_tDJ7U"; // API-nøkkel til Google Pollen API
        private readonly string _baseUrl = "https://pollen.googleapis.com/v1/forecast:lookup"; // API-endepunkt

        public PollenAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient; // Avhengighetsinjeksjon av HttpClient
        }

        public async Task<ApiPollenResponse?> HentPollenDataAsync()
        {
            // Bygger forespørsel med koordinater for Tønsberg og 5 dagers varsel
            string url = $"{_baseUrl}?location.latitude=59.26754&location.longitude=10.40762&days=5&key={_apiKey}";

            try
            {
                Console.WriteLine($"🌍 Henter pollen-data fra URL: {url}");

                var response = await _httpClient.GetAsync(url); // Sender GET-forespørsel
                response.EnsureSuccessStatusCode(); // Kaster unntak ved feilstatus

                var json = await response.Content.ReadAsStringAsync(); // Leser JSON-responsen som tekst

                Console.WriteLine("📥 API-respons mottatt:");
                Console.WriteLine(json); // Logger rådata for feilsøking

                // Deserialiserer JSON-tekst til ApiPollenResponse-objekt
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

                return pollenResponse; // Returnerer deserialisert objekt
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Feil under API-kall eller parsing: {ex.Message}");
                return null; // Returnerer null ved feil
            }
        }
    }
}
