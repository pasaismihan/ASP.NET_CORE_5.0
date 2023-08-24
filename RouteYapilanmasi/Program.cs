var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();  // Gelen istege gore ilgili controlleri ayaga kaldirmakla ve ilgili actiona yonlendirmekle gorevli middlewaredir.
// app.UseEndpoints middlewaremiz vardi birde , bu onceki yaptigimiz projelerde startupda bulunan rotalari tanimlama islemini ustelen yapidir , Fakat hazir mvc projesi actigimizda app.UseEndpoints gelmemektedir

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute(); /* default olarak hangi controllerimiz var ise (fonksiyon detaylarinda yazmakta) onu tetikleyecektir . Bu fonksiyon taniminda bulunan default controller , action ve id yi baz alirsak
   bir rota sablonunda suslu parantez icerisinde yazilan degerler parametrelere karsilik gelmektedir, controller ve action parametreleri on tanimli oldugu icin sistem bunu farkederek hangi controllerin hangi
   actionunu tetikleyecegini bilir , orada bulunan id degeri on tanimli degidir onu da yazmak zorunda degiliz cunku "?" ile belirttigimiz icin nullable olabilir diyoruz*/

    endpoints.MapControllerRoute("Default","{action=Index}/{controller=Employee}"); // burada default olarak kendimiz costumize ettik ilk basta actionun gelmesini sonrasinda controlleri degistirrerek employee gelmesini sagladik

    endpoints.MapControllerRoute("Default2", "anasayfa", new { controller = "Home", action = "Index" }); /*eger direkt olarak belirledigimiz statik bir rota( ornegin anasayfa) routing i ile istedigimiz rotaya 
                                                                                                                             gitmek istiyorsak onu new keywordu ile bir controller ve actiona baglamamiz gerekiyor  */

    // Yukaridaki gibi birden fazla endpoint olusturabiliriz fakat !!! bunun ozelden defaulta gitmesi gerekiyor ki once ozellestirdigimiz routingler tetiklensin...

    #region ROUTE CONSTRAINTS
    endpoints.MapControllerRoute("Default3", "{controller=Home}/{action=Index}/{id?}/{x}/{y}");
    /* Ustteki route costum sablonuna gore id , x ve y parametrelerimiz vardir Index actionu icerisinde , bunlari string tanimli yaparsak tum degerleri karsilayacaktir fakat bazi durumlarda karsilamasini
    istemeyiz ornegin kisitlayarak yalnizca int degerleri almalarini isteriz bu durumda yaptigimiz islem ROUTE CONSTRAINTS dir */
    // Ornegin id parametresini int ile kisitlamak istersek ilgili route sablonuna gidip {id:int?} ile degistirmemiz gerekir boylelikle id sadece int degeri olup ayni zamanda nullable olabilir
    // ayni mantikla {x:length(12)} diyerek x parametresine karsilik gelecek rotayi 12 hane olmasi icin zorluyoruz ornegin tc kimlik icin 11 haneli yaptik gibi ... 
    #endregion
});

app.Run();

