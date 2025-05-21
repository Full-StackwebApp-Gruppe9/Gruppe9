using Microsoft.AspNetCore.Mvc;
using Gruppe9.Models;
using Gruppe9.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Gruppe9.Controllers
{
    public class PollenAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PollenAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.IndexInfo
                .Include(i => i.ColorInfo)
                .ToList();

            ViewBag.Antall = data.Count;

            return View(data);
        }

        // ✅ Behold denne
        private ColorInfo GetColorForValue(int value)
        {
            return value switch
            {
                <= 2 => new ColorInfo { Red = 0, Green = 200, Blue = 0 },     // Grønn
                <= 4 => new ColorInfo { Red = 255, Green = 255, Blue = 0 },   // Gul
                _ => new ColorInfo { Red = 255, Green = 0, Blue = 0 }         // Rød
            };
        }
    }
}
