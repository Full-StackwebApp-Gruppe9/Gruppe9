using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Gruppe9.Models;

namespace Gruppe9.Controllers;

// Kontroller for startside og generelle visninger som ikke er koblet til forretningslogikk
public class HomeController : Controller
{
    // Logger brukes til å logge informasjon, advarsler eller feil fra HomeController
    private readonly ILogger<HomeController> _logger;

    // Dependency Injection av logger
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Viser startsiden (Index.cshtml i Views/Home)
    public IActionResult Index()
    {
        return View();
    }

    // Viser personvernsiden (Privacy.cshtml i Views/Home)
    public IActionResult Privacy()
    {
        return View();
    }

    // Vises ved feil. Viser en feilsidemodell med forespørsels-ID for sporing.
    // ResponseCache deaktiveres for å sikre at feilsiden alltid er fersk.
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}