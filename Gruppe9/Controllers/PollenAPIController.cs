using Microsoft.AspNetCore.Mvc;
using Gruppe9.Models;
using System.Collections.Generic;

namespace Gruppe9.Controllers
{
    public class PollenAPIController : Controller
    {
        public IActionResult Index()
        {
            // Minimal testdata (2–3 varsler)
            var data = new List<IndexInfo>
            {
                new IndexInfo
                {
                    ID = 1,
                    Code = "BIRCH",
                    DisplayName = "Bjørk",
                    Value = 2,
                    Category = "Low",
                    IndexDescription = "Lite bjørkepollen",
                    ColorInfo = GetColorForValue(2)
                },
                new IndexInfo
                {
                    ID = 2,
                    Code = "GRASS",
                    DisplayName = "Gress",
                    Value = 5,
                    Category = "High",
                    IndexDescription = "Høyt nivå av gresspollen",
                    ColorInfo = GetColorForValue(5)          }
            };

            return View(data);
        }

        private ColorInfo GetColorForValue(int value)
        {
            return value switch
            {
                <= 2 => new ColorInfo { Red = 0, Green = 200, Blue = 0 },     // Grønn
                <= 4 => new ColorInfo { Red = 255, Green = 255, Blue = 0 },   // Gul
                _    => new ColorInfo { Red = 255, Green = 0, Blue = 0 }      // Rød
            };
        }
    }
}