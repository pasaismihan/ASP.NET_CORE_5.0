using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCProjectEx_.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCProjectEx_.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
       public IActionResult GetProducts() // Olusturacagimiz view file inin ismi action metodunun adiyla ayni olmalidir 
      {
         Products product = new Products(); // product veritabanindan alinan veriyi model de isledik ve controller da bu veriyi istedik ve burada cagirmis olduk , view da oldugu gibi 
            return View(); // belirtilen view adindaki view dosyasini render eder 
       }
        // ACTION TURLERI
        #region ViewResult
        //public ViewResult GetProducts()
        //{
        // Oncesinde gordugumuz gibi ilgili viewu render etmeyi saglayan action turudur
        // ViewResult result = View();
        // return result;
        //}
        #endregion
        #region PartialViewResult
        // client tabanli ajax isteklerinde kullandigimiz action turudur . view resulttan bir diger farki da parcaya etki etmesidir .
        //public PartialViewResult GetProducts()
        //{
        //    PartialViewResult result = PartialView();
        //    return result;
        //}
        #endregion
        #region JsonResult
        // uretilen datayi jSON formatina donusturup donduren action turudur
        //public JsonResult GetProducts()
        //{
        //    JsonResult result = Json(new Products
        //    {
        //        Id = 5,
        //        ProductName = "TERLIK",
        //        TotalProduct= 5
        //    });
        //    return result;
        //} Bu sekilde veriyi jSON formatinda gondeririz tarayicida bu bilgileri goruruz
        #endregion
        #region EmptyResult
        //public EmptyResult GetProducts()
        //{
        //    return new EmptyResult(); // eger responce olarak bir result dondurmek istemezsek kullaniriz. Yine basarili bir responce dondurmus oluruz yalnizca sayfada bir result olmaz
        //}
        #endregion
        #region ContentResult
        //public ContentResult GetProducts()
        //{
        //    ContentResult result = Content("bu yazilan tarayiciya text olarak gonderilir .... ");
        //    return result;
        //}
        #endregion
        #region ActionResult
        // result turlerinin base classidir  . ornegin json formatinda donucez ve partial turunde donucez bunlari ortak bir yerde yapmak icin actionresult kullaniriz
        #endregion
        #region IActionResult
        // yine action result gibi base classdir . Sadece onun intefacesidir 
        #endregion
        // NONACTION & NONCONTROLLER 
        #region NonAction ve NonController
        public IActionResult Index()
        {
            X();
            return View();
        }
        [NonAction]
        public void X()
        {
            // Bir metod eger controller sinifi icinde ise bu sinifin action turlerinden biri olmasi sart degil , gerekli routing ozelliklerini verirsek requestleri karsilamis oluruz . Actionlarin gorevi requestleri karsilayip
            // yonlendirmektir , is yapmazlar . isi yaptiran taraftir fakat belli basli durumlarda is yapmasi gereken bir action var ise bunun request almamasini saglamak icin [NonAction] attribute u ile isaretlememiz gerekir
        }
        #endregion

        //VIEW YAPILANMASI VE VIEW'A VERI TASIMA KONTROLLERI
        public IActionResult IndexProduct()
        {
            var product = new List<Products>
            {
                new Products{ProductName= "koltuk" , Id=1, TotalProduct = 5},
                new Products{ProductName= "sandalye" , Id=2, TotalProduct = 15}
            };
            return View();
        }
        // Model Bazli Veri Gonderimi
        // modelda olusturdugumuz veriyi controller da view a gondermek icin ustteki ornegi kullanarak return View(product); dememiz gerekir boylelikle bu degerler View katmanina gidecektir
        // View da bu gonderilen veriyi alabilmemiz icin @model keywordu vardir . @model List<MVCProjectEx_.Models.Products> yazmaliyiz .
        // daha sonra ilgili datalari sirali bir sekilde vermek istedik diyelim asagidaki islemi yapariz
        /*
         @model List<MVCProjectEx_.Models.Products>
            <ul>
                @foreach(var products in Model)
                {
                <li>@products.ProductName</li>
                }
            </ul>  bu islemi view icerisinde yaparsak gelen datayi sirali bir sekilde tarayicida goruruz
        */
        //Veri Tasima Kontrolleri
        #region ViewBag
        // Viewa gonderilecek veya tasinacak datayi dynamic sekilde tanimlanan bir degiskenle tasimamizi saglayan bir veri tasima kontroludur
        // yukarida yazdigimiz var products ... kismini tekrarliyoruz devaminda da ViewBag.products = products dedigimizde artik ViewBag ile veri tasiyabiliriz
        // bu durumda olusturacagimiz foreach degisir yani
        /*
           <ul>
            @foreach(var products in ViewBag.products as List<MVCProjectEx_.Models.Products>)
            {
            < li > @products.ProductName </ li >
            }
          </ul> 
        */
        #endregion
        #region ViewData
        // ViewBag de oldugu gibi actiondaki datayi viewa tasimamizi saglayan kontroldur ,  fakat bu veri tasima kontrolunde farkli olarak boxing gondeririz view da unboxing yapmamiz gerekir
        // ViewData["products"] = products 
        #endregion
        #region TempData
        // ViewData da oldugu gibi actiondaki datayi viewa tasimamizi saglayan kontroldur ,  fakat bu veri tasima kontrolunde farkli olarak boxing gondeririz view da unboxing yapmamiz gerekir
        // TempData["products"] = products
        // Fakat TempDatayi ViewDatadan ayiran fark session cooke leri kullanmasidir bu sadece baska actionlara veri tasimamizi saglayabilir(gormek istedigimizde tarayicidaki session storage bolumunde buluruz)
        // ilgili actionumuz icerisinde ;
        // return RedirectToActionResult("Index2","Products"); belirttigimizde Index2 icerisindeki verileri tasimis oluruz
        #endregion


    }
}

