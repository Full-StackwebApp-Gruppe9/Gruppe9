using Gruppe9.Models;

namespace Gruppe9.Services
{
    // Definerer kontrakten for en tjeneste som henter pollendata fra eksternt API
    public interface IPollenAPIService
    {
        Task<ApiPollenResponse?> HentPollenDataAsync(); // Henter pollendata asynkront fra API-et
    }
}
