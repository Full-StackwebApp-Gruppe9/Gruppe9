using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Gruppe9.Data;

var builder = WebApplication.CreateBuilder(args);

// 💾 Legg til ApplicationDbContext og SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=pollen.db"));  // Du kan endre filnavnet her hvis du vil

// 📦 MVC-støtte
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🌐 Middleware for ulike miljø
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

// 🧭 Ruting og statiske filer
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
