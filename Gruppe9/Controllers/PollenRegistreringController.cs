using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gruppe9.Data;
using Gruppe9.Models;

namespace Gruppe9.Controllers
{
    public class PollenRegistreringController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PollenRegistreringController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PollenRegistrering
        public async Task<IActionResult> Index()
        {
            return View(await _context.PollenRegistrering.ToListAsync());
        }

        // GET: PollenRegistrering/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: PollenRegistrering/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    if (!PollenRegistreringExists(pollenRegistrering.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pollenRegistrering);
        }

        // GET: PollenRegistrering/Delete/5
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

        private bool PollenRegistreringExists(int id)
        {
            return _context.PollenRegistrering.Any(e => e.ID == id);
        }
    }
}
