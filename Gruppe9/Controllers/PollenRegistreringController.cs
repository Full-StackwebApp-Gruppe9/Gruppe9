
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gruppe9.Data;
using Gruppe9.Models;

namespace Gruppe9.Controllers
{
    // Kontroller for CRUD-operasjoner på PollenRegistrering-modellen
    public class PollenRegistreringController : Controller
    {
        // Databasekontekst injiseres via dependency injection
        private readonly ApplicationDbContext _context;

        public PollenRegistreringController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PollenRegistrering
        // Viser liste over alle pollenregistreringer
        public async Task<IActionResult> Index()
        {
            return View(await _context.PollenRegistrering.ToListAsync());
        }

        // GET: PollenRegistrering/Details/5
        // Viser detaljer for én spesifikk registrering basert på ID
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollenRegistrering = await _context.PollenRegistrering
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pollenRegistrering == null)
            {
                return NotFound();
            }

            return View(pollenRegistrering);
        }

        // GET: PollenRegistrering/Create
        // Viser skjema for å opprette ny registrering
        public IActionResult Create()
        {
            return View();
        }

        // POST: PollenRegistrering/Create
        // Validerer og lagrer ny registrering i databasen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,TypeOfPollen,Level")] PollenRegistrering pollenRegistrering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pollenRegistrering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pollenRegistrering);
        }

        // GET: PollenRegistrering/Edit/5
        // Henter eksisterende registrering og viser redigeringsskjema
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollenRegistrering = await _context.PollenRegistrering.FindAsync(id);
            if (pollenRegistrering == null)
            {
                return NotFound();
            }
            return View(pollenRegistrering);
        }

        // POST: PollenRegistrering/Edit/5
        // Validerer og oppdaterer eksisterende registrering
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,TypeOfPollen,Level")] PollenRegistrering pollenRegistrering)
        {
            if (id != pollenRegistrering.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pollenRegistrering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Hvis dataen er endret/slettet av noen andre under redigering
                    if (!PollenRegistreringExists(pollenRegistrering.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // Kast videre hvis det er en annen feil
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pollenRegistrering);
        }

        // GET: PollenRegistrering/Delete/5
        // Viser bekreftelsesside før sletting
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pollenRegistrering = await _context.PollenRegistrering
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pollenRegistrering == null)
            {
                return NotFound();
            }

            return View(pollenRegistrering);
        }

        // POST: PollenRegistrering/Delete/5
        // Utfører selve slettingen av registreringen
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pollenRegistrering = await _context.PollenRegistrering.FindAsync(id);
            if (pollenRegistrering != null)
            {
                _context.PollenRegistrering.Remove(pollenRegistrering);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Hjelpemetode for å sjekke om en registrering finnes basert på ID
        private bool PollenRegistreringExists(int id)
        {
            return _context.PollenRegistrering.Any(e => e.ID == id);
        }
    }
}
