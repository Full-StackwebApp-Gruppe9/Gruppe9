using Microsoft.AspNetCore.Mvc;
using Gruppe9.Models;
using Gruppe9.Data;
using Microsoft.EntityFrameworkCore;
using Gruppe9.Helpers;

namespace Gruppe9.Controllers
{
    public class PollenAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PollenAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _context.IndexInfo
                .Include(i => i.ColorInfo)
                .ToListAsync();

            ViewBag.Antall = data.Count;

            return View(data);
        }
    }
}
