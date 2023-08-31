var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
/* Areas arayuzle yonetici katmanini ayirmamizi saglamak icin kullandigimiz bir yapidir cokkatmanli degildir . herbir area kendi icerisinde controller model ve view barindirabilir.
boylece ASPNET Core uygulamarinda yonetilebilir kucuk islevsel gruplar olusturabiliriz*/
// Arealarin kullanim yerlerine ornekler ; Yonetim Panelleri , Faturalandirma Sayfalari , Istatistiksel Paneller , Islevsel Moduller vs.

// Arealar icerisinde ayni isimde Controller olabilir , ayni zamanda Kok dizindeki Controller adi da ayni olabilir ornegin 2 farkli HomeController var ise Area Attributesi kullanarak [Area("yonetim_paneli")] diye ayirabiliriz

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
    name: "areaDefault",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    ); // Area olan controllerlara yonlendirmek icin bu sekilde bir rota olusturuyoruz
app.MapAreaControllerRoute(
    name: "myArea",
    areaName: "yonetim_paneli",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}"
    );// Area olan controllerlara yonlendirmek icin bu sekilde bir rota olusturuyoruz

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

