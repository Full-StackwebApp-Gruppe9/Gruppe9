using Microsoft.AspNetCore.Mvc;
using Gruppe9.Models;

namespace Gruppe9.Controllers
{
    public class PollenAPIController : Controller
    {
        public IActionResult Index()
        {
            var testData = new List<IndexInfo>
            {
                new IndexInfo
                {
                    Code = "brk",
                    DisplayName = "Bjørk",
                    Value = 3,
                    Category = "Moderat",
                    IndexDescription = "Moderat nivå av bjørkepollen",
                    ColorInfo = new ColorInfo { Red = 255, Green = 230, Blue = 200 }
                },
                new IndexInfo
                {
                    Code = "gras",
                    DisplayName = "Gress",
                    Value = 1,
                    Category = "Lav",
                    IndexDescription = "Lite gresspollen i lufta",
                    ColorInfo = new ColorInfo { Red = 200, Green = 255, Blue = 200 }
                }
            };

            return View(testData);
        }
    }
}