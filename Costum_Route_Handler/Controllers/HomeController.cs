using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Costum_Route_Handler.Models;

namespace Costum_Route_Handler.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        // Genel gecer operasyonlarda (yani authentication, form , vs herhangi bir istek olabilir ) controllera yonlendirip requesti karsilamamiz gerekir . 
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

