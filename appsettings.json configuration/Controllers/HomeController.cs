using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using appsettings.json_configuration.Models;

namespace appsettings.json_configuration.Controllers;

public class HomeController : Controller
{
    readonly IConfiguration _configuration; 

    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
    } // burada dependency injection yapilanmasini kullanarak IConfiguration servisini cagirdik ve ihtiyacimiz oldugu derecede kullandik .

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var v1 = _configuration["OrnekMetin"]; // Bu yontem Indexer ile veri okuma yontemidir ... !!!!
        var v2 = _configuration["Person:Name"];
        var v3 = _configuration["Person:Surname"]; // json turunde bir alt objecte inebilmek icin : isaretini kullaniriz _configuration referansi bizi appsetting.json dosyasina goturdu
        var v4 = _configuration["Logging:LogLevel:Microsoft.AspNetCore"];
        var v5 = _configuration.GetSection("Person"); // getsection ozelligi appsetting icindeki degerler icin kullanilir fakat farkli olarak alan sonucu verir direkt olarak ilgili degeri vermez onu ayrica almamiz grekir
        var v6 = _configuration.GetSection("Person").Get(typeof(Person));// appsettings.json icerisindeki Name ve Surname degerlerinin oldugu modeli Person classi olarak olusturduk , bu classin tipi oldugu
                                                                                     // degerleri bize geri donu demek icin Get metodunu kullaniyoruz
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

