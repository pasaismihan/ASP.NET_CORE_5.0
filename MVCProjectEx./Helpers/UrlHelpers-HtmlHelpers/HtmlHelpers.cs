using System;
namespace MVCProjectEx_.UrlHelpersHtmlHelpers
{
	public class HtmlHelpers
	{
        // Html etiketlerini server tabanli olusturmamizi saglayan yardimci metodlari barindirmaktadir. fakat bunu yaparken servera yuk bindirmektedir
        // Hedeflenen .cshtml uzantili dosyalari render etmemizi saglamakta
        // O anki contexte dair bilgiler edinmemizi saglamakta
        // Veri tasima kontrollerine erisimimizi saglamaktadir

        // HTMLHELPERS METODLARI
            // Html.Partial Metodu -> hedef view u render etmemizi saglayan bir fonksiyondur bu herhangi bir view olabilir
                // bunun icin controllera gitmesine gerek yok view icerisinde render islemi yapiyoruz ( View(); gorevi ) . Render edilen viewa ilgili actiondan model/ data gonderilebilmektedir yani illa ki ayni action adina sahip view olmasi sart degil
                // ornek olarak product actionu uzerinde ve viewu uzerinde calisiyoruz , fakat employee viewunu da render etmek istedik. bu duruma product view u icerisine @Html.Partial("~/Views/Employees/Employee.cshtml") kodunu yazdigimizda employee viewu da render edilir
                /*<div style.......>
                     @Html.Partial("~/Views/Product/Index.cshtml")
                   </div>*/
            // Html.RenderPartial Metodu -> hedef view u render etmemizi saglayan bir fonksiyondur , mantik olarak html.partial ile ayni calisir fakat daha hizli render edilir daha performanslidir
                // @{ Html.Partial("~/Views/Product/Index.cshtml"); }
    }
}

