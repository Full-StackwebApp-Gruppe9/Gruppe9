using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Gruppe9.Data;
using Gruppe9.Services;
using Gruppe9.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gruppe9.Services
{
    public class PollenDataHostedService : IHostedService
    {
        private readonly IServiceProvider _services;

        public PollenDataHostedService(IServiceProvider services)
        {
            _services = services;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var pollenService = scope.ServiceProvider.GetRequiredService<IPollenAPIService>();

            var data = await pollenService.HentPollenDataAsync();

            if (data != null)
            {
                foreach (var day in data.DailyInfo)
                {
                    foreach (var index in day.Indexes)
                    {
                        var color = index.Value switch
                        {
                            <= 2 => new ColorInfo { Red = 0, Green = 200, Blue = 0 },
                            <= 4 => new ColorInfo { Red = 255, Green = 255, Blue = 0 },
                            _ => new ColorInfo { Red = 255, Green = 0, Blue = 0 }
                        };

                        var existingColor = context.ColorInfo.FirstOrDefault(c =>
                            c.Red == color.Red && c.Green == color.Green && c.Blue == color.Blue);

                        if (existingColor == null)
                        {
                            context.ColorInfo.Add(color);
                            await context.SaveChangesAsync();
                            existingColor = color;
                        }

                        var indexInfo = new IndexInfo
                        {
                            Code = index.Code,
                            DisplayName = index.DisplayName,
                            Value = index.Value,
                            Category = index.Category,
                            IndexDescription = index.IndexDescription,
                            ColorInfoId = existingColor.Id
                        };

                        context.IndexInfo.Add(indexInfo);
                    }
                }

                await context.SaveChangesAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
