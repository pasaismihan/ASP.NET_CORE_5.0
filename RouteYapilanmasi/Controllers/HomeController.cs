using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RouteYapilanmasi.Models;

namespace RouteYapilanmasi.Controllers;


#region ATTRIBUTE ROUTING
// Routinglerin attributelerini de costumize edebiliriz yani , routing yaparken belirttigimiz controller ve action parametrelerinin on tanimli kisimlarinin da adini degistirebiliriz
// Bu islemi HomeController uzerinde yapmak istersek asagidaki attribute tanimini olusturmamiz gerekir
[Route("[kontroleden]/[isiyapan]")] // burada dikkat ceken kisim default attributeleri biz suslu parantezle kullaniyorduk ({controller=home}/{action=index}) fakat Route ozelligi kullanirken koseli parantez ile yapiyoruz
// Ayrica bu ozelligi kullandigimizda istekleri alabilmesi icin program.cs tarafinda endpoints.MapControllers(); ile belirtmemiz gerekir
// ayriyeten [Route("class")] seklinde yazarsak controller uzerinde oldugu icin controllerin adini costumize etmis olacagiz 
#endregion
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    // [Route("isyapan")] seklinde action uzerinde yazarsak yine controller gibi costumize etmis oluruz ... id ve diger parametreleri de yine suslu parantezle devaminda yazabiliriz
    public IActionResult Index(string id , string x , string y)
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

