using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace MVCProjectEx2.Controlers
{
    public class ProductController : Controller
    {
    
        public IActionResult GetProduct()
        {
            return View();
        }
    }
}

