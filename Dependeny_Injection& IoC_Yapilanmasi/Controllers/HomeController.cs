using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dependeny_Injection__IoC_Yapilanmasi.Models;
using Dependeny_Injection__IoC_Yapilanmasi.Services;
using Dependeny_Injection__IoC_Yapilanmasi.Services.Interfaces;

namespace Dependeny_Injection__IoC_Yapilanmasi.Controllers;

public class HomeController : Controller
{

    readonly Ilog _log; //   public Ilog _log { get; } bununla ayni islem Ilog interfacesi turunden property olusturuyoruz , daha sonra o property yi okumasi icin constructor da tanimliyoruz

    public HomeController(Ilog log)
    {
       _log = log;
    }
    // yukarida controller bazli ilgili nesneyi cagirmayi gorduk ama action bazli cagirmak istersek ilgili actionun parametre bolumune ([FromServices]Ilog log) yazariz yani controller dan degil direkt olarak containerdan nesneyi getir demektir

    public IActionResult Index()
    {
        _log.Log(); // burada Ilog interfacesi tarafindan olusturdugumuz property oldugu icin program.cs de hangi nesneyi cagirirsak eger bu actionda onun metodu harekete gececektir
        ConsoleLog log = new ConsoleLog(5);
        log.Log(); // burada loglama islemi yaptik console da yapilan degisiklikler ilgili metoda gelecek FAKAT!!! burada ConsoleLog yerine TextLog da loglama yapmak istesek degistirmek zorunda kalicaz
                   // new keywordu ile yaptigimizda bu sekilde bagimlilik olustu simdi bizim buraya IoC yapilanmasi kullanarak Dependency Injection design patternini yerlestirmemiz lazim
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

