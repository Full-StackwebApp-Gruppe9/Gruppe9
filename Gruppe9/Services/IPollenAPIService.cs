using System.Threading.Tasks;
using Gruppe9.Models;

namespace Gruppe9.Services
{
    public interface IPollenAPIService
    {
        Task<ApiPollenResponse?> HentPollenDataAsync();

    }
}
