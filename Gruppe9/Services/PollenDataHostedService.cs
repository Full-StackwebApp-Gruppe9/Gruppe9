using Gruppe9.Data;
using Gruppe9.Models;
using Gruppe9.Helpers;

// Importtjeneste som henter og lagrer pollendata ved oppstart
namespace Gruppe9.Services
{
    public class PollenDataHostedService : IHostedService
    {
        private readonly IServiceProvider _services; // Håndterer tjenestetilgang via Dependency Injection

        public PollenDataHostedService(IServiceProvider services)
        {
            _services = services;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _services.CreateScope(); // Oppretter et scoped tjenestemiljø
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>(); // DB-kontekst
            var pollenService = scope.ServiceProvider.GetRequiredService<IPollenAPIService>(); // API-tjeneste

            var data = await pollenService.HentPollenDataAsync(); // Henter pollen-data fra API

            if (data == null)
            {
                Console.WriteLine("⚠️  API-respons var null – ingen data hentet.");
                return;
            }

            Console.WriteLine($"✅ API-data mottatt: {data.DailyInfo.Count} dager");

            // Sletter tidligere data fra databasen (kun for testing)
            context.IndexInfo.RemoveRange(context.IndexInfo);
            await context.SaveChangesAsync();

            int antallLagret = 0;

            foreach (var day in data.DailyInfo)
            {
                string dato = day.Date ?? "Ukjent";
                int antallPlanter = day.PlantInfo?.Count ?? 0;

                Console.WriteLine($"📅 Dato: {dato}, antall planter: {antallPlanter}");

                if (day.PlantInfo == null)
                    continue; // Hopper over dagen hvis ingen planter

                foreach (var plant in day.PlantInfo)
                {
                    var index = plant.IndexInfo;
                    if (index == null) continue; // Hopper over planter uten indeks

                    Console.WriteLine($"🌿 {plant.Code} – {plant.DisplayName} – {index.Value}");

                    var color = PollenColorHelper.GetColorForValue(index.Value); // Henter farge basert på indeks

                    var existingColor = context.ColorInfo.FirstOrDefault(c =>
                        c.Red == color.Red && c.Green == color.Green && c.Blue == color.Blue); // Gjenbruker farge hvis den finnes

                    if (existingColor == null)
                    {
                        context.ColorInfo.Add(color); // Lagrer ny farge i databasen
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

                    context.IndexInfo.Add(indexInfo); // Lagrer indeksdata for planten
                    Console.WriteLine($"➕ Lagret pollen: {plant.Code} ({plant.DisplayName}) - {index.Value} - {dato}");
                    antallLagret++;
                }
            }

            await context.SaveChangesAsync(); // Utfører lagring av alle rader
            Console.WriteLine($"✅ Pollen-data lagret! Totalt: {antallLagret} rader.");
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask; // Ingen logikk ved stopp
    }
}
