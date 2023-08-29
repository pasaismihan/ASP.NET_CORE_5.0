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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// asagida yapilan islem costum route handler fonksiyonudur fakat bu sekilde yapmak yerine handler adinda bir dosya acip orada class olusturup ilgili fonksiyonu orada yaziyoruz ve bu tarafta cagiriyoruz
app.Map("example-route", async c =>
{
    // https://www.localhost5001/example-route endpointe gelen herhangi bir istek controllera degil buradaki fonksiyon tarafindan karsilanacaktir
    // async yapmamizin nedeni bu Map fonksiyonunun configurasyonunda delegate keywordu ile olusan sinif vardir ve bu sinif task middleware i ile calisir, bu taskin responcesini beklemek icin asenkron yapariz
});
app.Run();

/* ONEMLI BILGI ---> Her zaman gelen requestin controller tarafindan karsilanmasini istemeyiz. Herhangi bir belirlenmis route semasinin controller siniflarindan ziyade business mantigiyla karsilanmasi ve
orada is gorup responcenin donmesine Costum Route Handler denir*/
// Costum Route Handler ozellestirilmis route semalarinda kullanilir , daha cok mimarisel yapilarda karsimiza cikar.
// map ile baslayan tum metodlar route lari temsil eder  

