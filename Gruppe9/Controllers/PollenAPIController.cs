using Microsoft.AspNetCore.Mvc;
using Gruppe9.Data;
using Microsoft.EntityFrameworkCore;

namespace Gruppe9.Controllers
{
    // Kontroller for visning av pollenvarsler via API-data lagret i databasen
    public class PollenAPIController : Controller
    {
        // Databasekonteksten injiseres via dependency injection
        private readonly ApplicationDbContext _context;

        public PollenAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Henter pollenvarsel-data fra databasen og sender det til visningen
        // Inkluderer ColorInfo-relasjon for å kunne vise farger i view
        public async Task<IActionResult> Index()
        {
            var data = await _context.IndexInfo
                .Include(i => i.ColorInfo) // Eager loading av tilhørende fargeinfo
                .ToListAsync();

            ViewBag.Antall = data.Count; // Sender antall elementer til view via ViewBag

            return View(data); // Returnerer viewet med liste av IndexInfo
        }
    }
}