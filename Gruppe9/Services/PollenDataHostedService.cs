using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Gruppe9.Data;
using Gruppe9.Services;
using Gruppe9.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

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

            if (data == null)
            {
                Console.WriteLine("⚠️  API-respons var null – ingen data hentet.");
                return;
            }

            Console.WriteLine($"✅ API-data mottatt: {data.DailyInfo.Count} dager");

            // Tøm tidligere data (kun for testing)
            context.IndexInfo.RemoveRange(context.IndexInfo);
            await context.SaveChangesAsync();

            int antallLagret = 0;

            foreach (var day in data.DailyInfo)
            {
                string dato = day.Date ?? "Ukjent";
                int antallPlanter = day.PlantInfo?.Count ?? 0;

                Console.WriteLine($"📅 Dato: {dato}, antall planter: {antallPlanter}");

                // 🔒 Sjekk for null før foreach
                if (day.PlantInfo == null)
                    continue;

                foreach (var plant in day.PlantInfo)
                {
                    var index = plant.IndexInfo;
                    if (index == null) continue;

                    Console.WriteLine($"🌿 {plant.Code} – {plant.DisplayName} – {index.Value}");

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
                        Code = plant.Code,
                        DisplayName = plant.DisplayName,
                        Value = index.Value,
                        Category = index.Category,
                        IndexDescription = index.IndexDescription,
                        ColorInfoId = existingColor.ID,
                        Date = dato
                    };

                    context.IndexInfo.Add(indexInfo);
                    Console.WriteLine($"➕ Lagret pollen: {plant.Code} ({plant.DisplayName}) - {index.Value} - {dato}");
                    antallLagret++;
                }
            }

            await context.SaveChangesAsync();
            Console.WriteLine($"✅ Pollen-data lagret! Totalt: {antallLagret} rader.");
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
