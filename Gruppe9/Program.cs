using Microsoft.EntityFrameworkCore;
using Gruppe9.Data;
using Gruppe9.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔌 Registrerer HttpClient for API-tjenesten
builder.Services.AddHttpClient<IPollenAPIService, PollenAPIService>();

// 💾 Konfigurerer ApplicationDbContext med SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=pollen.db")); // Lokal databasefil

// 📦 Legger til støtte for MVC (kontrollere og views)
builder.Services.AddControllersWithViews();

// ⚙️ Registrerer bakgrunnstjenesten for automatisk dataimport
builder.Services.AddHostedService<PollenDataHostedService>();

var app = builder.Build();

// 🌐 Middleware for feilbehandling og sikkerhet i produksjon
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Viser feilsider i produksjon
    app.UseHsts(); // Bruker HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // Tvinger HTTPS
app.UseRouting();          // Aktiverer ruting
app.UseAuthorization();    // Legger til tilgangskontroll

// 🧭 Kartlegger statiske filer og ruting
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}") // Standardrute
    .WithStaticAssets();

app.Run(); // Starter applikasjonen
