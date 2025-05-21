using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Gruppe9.Models;

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
            string url = $"{_baseUrl}?location.latitude=59.26754&location.longitude=10.40762&days=5&key={_apiKey}";

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var contentStream = await response.Content.ReadAsStreamAsync();
                var pollenResponse = await JsonSerializer.DeserializeAsync<ApiPollenResponse>(
                    contentStream,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return pollenResponse;
            }
            catch
            {
                return null;
            }
        }

    }
}
