using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace MVCProjectEx_.Controllers
{
    public class HomeController : Controller // bir sinifi request alabilir ve responce dondurebilir hale getirmek icin yani controller ozelligini almak icin o sinif Controller classindan kalitim almalidir
    {
        // controller icerisindeki metotlar action dur .
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}

