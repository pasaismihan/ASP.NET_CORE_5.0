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
        // Bir action metodu default olarak get turunden http ozelligidir...
        #region ACTION TURLERI , VIEW YAPILANMASI VE VIEW VERI TASIMA KAPASITESI 

  
        // GET: /<controller>/
        // public IActionResult GetProducts() // Olusturacagimiz view file inin ismi action metodunun adiyla ayni olmalidir 
        //{
        //   Products product = new Products(); // product veritabanindan alinan veriyi model de isledik ve controller da bu veriyi istedik ve burada cagirmis olduk , view da oldugu gibi 
        //      return View(); // belirtilen view adindaki view dosyasini render eder 
        // }
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
        #endregion
        #region MODEL BINDING
        /* Model binding kullanim alani su sekilde ortaya cikar , bir user eger sunucuya veri gonderirse(post islemi yaparsa) bu verileri eslestirmek baglamak icin ayni bilgilerin backend de de bulunmasi gerekiyor
        ornegin input girmektedir adi , soyadi , yasi . bu input degerlerini girip buttona tikladiktan sonra post gonderdigini varsayalim , backend de hangi birimin adi soyadi vs oldugunu bilemeyiz
        o yuzden backend de bir class olustururuz bu classla binding ederiz mesela class adi employee olsun , icerisinde adi , soyadi , yasi degerleri bulunsun , ilgili inputu buraya binding ettigimizde
        bu girilen degerlerin bir employee ye bagli oldugunu anlariz bu sekilde employee ile baglariz bu isleme model binding denir
        */
        public IActionResult GetProduct()
        {
            return View();
        }
        /*
        ===>  public IActionResult CreateProduct()
        {
            // CreateProduct ile post istegi gonderebilmek icin oncesinde onu ekranda okumak istiyoruz bu get istegini yapan metodun gorevi de odur
            Products product = new Products();
            return View(product);     //yeni post istegi gonderdigimizde satir olarak bu olusturdugumuz product uzerinden aliriz ilgili datalari. bu propery uzerine yazdirilacagi icin databaseye migrate edilir
            // bu yaptigimiz metod formumuza get istegi atmak icin kullandigimiz metoddur, formdan gelen post istegini yanitlamak icin asagida CreateProduct adinda yeni bir metod olusturuyoruz
            // cshtml uzantili view dosyamizda forum icerisinde asp-action adini CreateProduct olusturdugumuz icin yine metodu ayni isimde olusturuyoruz
        }
        [HttpPost] // asagidaki metodun post isteklerini alabilmesi icin olusturdugumuz http post turu
        ===>  public IActionResult CreateProduct(string txtProductName, string txtQuentity)
        {
            // request neticesinde actiona gelen datalarin hepsi ilgili actionun parametreleri tarafindan yakalanir 
            return View();
        }

    // !!! Yukaridaki post islemini yapmak icin kullandigimiz metodda parametreler ile inputlari yakalamak istedik fakat buyuk capli projelerde cok fazla input olacagi icin hepsine ayri ayri parametre yazmak zor olacaktir
    // bunun icin Products classini (model icerisindeki products class i ) parametre olarak kullaniyoruz cunku olusturdugumuz inputlarin aynisi ilgili model de mevcut , bu durumu kullanarak onu referans aliyoruz
      ===>  public IActionResult CreateProduct(Products product)
        {
            // eger ki inputlarin name attribute isimleri ile Products modelinin property isimleri birebir ortusurse sistem otomatik olarak iki tarafi bind eder yani birbirine baglar 
            return View();
        }
        */
        #endregion
        #region KULLANICIDAN VERI ALMA YONTEMLERI 
        #region FORM UZERINDEN VERI ALMA YONTEMI
        [HttpPost]
        public IActionResult CreateProductForm(IFormCollection datas)
        {
            var value1 = datas["txtValue1"].ToString();
            var value2 = datas["txtValue2"].ToString();
            var value3 = datas["txtValue3"].ToString();
            return View();
            // burada yapilan islem , IFormCollection ozel form paketi sayesinde name lerden yakaldik ve parametreyi kullanarak yazdirdik 
        }

        #endregion
        #region QUERYSTRING UZERINDEN VERI ALMA
        // QueryString => guvenlik gerektirmeyen bilgilerin url uzerinden tasinmasina denilen yapilanmadir . tanimlama yaparken ilgili url nin sonuna ? koyuyoruz daha sonra query bilgilerimizi giriyoruz
        [HttpPost]
        public IActionResult VeriAl(string a)
        {
            // a parametresini url de .......?a=5 seklinde ifade edersek bu istegi ilgili action yakalayacaktir. url de birden fazla querystring belirtmek icin aralarina & koymaliyiz
            var queryString = Request.QueryString; // request yapilan endpointe query string parametresi eklenmis mi eklenmemis mi ona bakiyor boolean deger donuyor
            var c = Request.Query["c"].ToString();
            var b = Request.Query["b"].ToString();
            return View();
        }
        #endregion
        #region ROUTE PARAMETER UZERINDEN VERI ALMA
        public IActionResult VeriAl2(string id)
        {
            // biz tarayiciya ilgili actiondan sonra yalnizca id icin ornegin /3 yazarsak bunu algilar ve id yerine o degeri verir
            var values = Request.RouteValues; // burada da ilgili degerleri yakalayabiliriz ayni islevi gorur
            return View();
        }
        #endregion
        #region HEADER UZERINDEN VERI ALMA
        public IActionResult VeriAl3()
        {
            var header = Request.Headers; // en dogru sekilde bu yontemle headers daki verileri cekebiliriz
            // bunu kullanmak icin postman uygulamasindaki header bolumunden key value kismina ilgili verileri girdigimizde bu metodumuza geliyor veriler
            return View();
        }
        #endregion
        #region AJAX ILE CLIENT TABANLI VERI ALMA
        // Ajax ile veri alabilmek icin oncelikle ilgili actionun view bolumunde script olusturmamiz gerekir
        /*
         <script src = "https://......"></script>
        <button id="btnGonder"> Gonder </button>

        <script>
        $("#btnGonder").click(()=>{
        $.post("https://localhost:5001/product/verial4",{a : "a data" , b : "b data"}
        });
        </script>
         */
        public IActionResult VeriAl4(AjaxVeriAl ajaxVeri)
        {

            // istersek parametre olarak ayri ayri belirtmektense ozel bir class olusturup onun iceirisinde ilgili datalari property seklinde olusturup bu metodda o class ve properyleri kullanabiliriz
            return View();
        }
        public class AjaxVeriAl
        {
            public string A { get; set; }
            public string B { get; set; }
        }

        #endregion
        #endregion
        #region TUPLE NESNE ILE POST ETME VE YAKALAMA
        public IActionResult CreateProductTuple()
        {
            var tuple = (new Products(), new Employee()); // degerler null donmesin diye view a yeni nesneler olusturup iletiyoruz 
            return View(tuple);
        }
        [HttpPost]
        public IActionResult CreateProductTuple([Bind(Prefix ="item1")]Products product , [Bind(Prefix ="item2")]Employee employee)
        {
            // bu metodun parametresinde [Bind(Prefix="item")] kullanmamizin nedeni , ilgili tuple degerlerini yakalayamiyor olusumuz , bu sekilde yaptigimizde view input icerisindeki asp-for degerlerinden yakaliyorz
            return View();
        }
        #endregion
        #region KULLANICIDAN GELEN VERILERIN DOGRULANMASI(VALIDATION)
        public IActionResult CreateProductValidation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProductValidation(Products model)
        {
            // ModelState ---> Mvc de bir type in data annotationlarinin durumunu check eden ve geriye sonuc donduren bir property dir , yani burada valid mi degil mi bunu bildirecegiz
            if (!ModelState.IsValid)
            {
                // asagidaki viewbag ile hata yakalama eski sistem . bunun yerine view da span olusturup asp-validation-for ozelligini kullaniyoruz
                // ViewBag.HataMesaj = ModelState.Values.FirstOrDefault(x => x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;
                // loglama
                // kullanici bilgilendirme
                var message = ModelState.ToList(); // propertyleri key value pair seklinde hata mesajlarini veriyor 
                return View(model);
            }
            // eger if blogundan gecerse valid oldugunu ogreniriz ve gerekli islemlere tabi tutariz
            return View();
        }

        #endregion
    }
}

