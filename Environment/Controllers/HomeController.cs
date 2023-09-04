using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Environment.Models;

namespace Environment.Controllers;

public class HomeController : Controller
{

    IWebHostEnvironment _webHostEnvironment;
    public HomeController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        if (_webHostEnvironment.IsDevelopment())
        {
            ViewBag.Env = "Development";
        }else if (_webHostEnvironment.IsProduction())
        {
            ViewBag.Env = "Production";
        }else if (_webHostEnvironment.IsStaging())
        {
            ViewBag.Env = "Staging";
        }
      //  var env = _webHostEnvironment.IsDevelopment(); // yani burada development asamasinda mi onu soruyoruz sonuc olarak boolean deger donuyor 
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

