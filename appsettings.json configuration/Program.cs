var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


/* IConfiguration --->ASP.NET Core provider inda bulunan bir servistir.Bu servis uygulamadaki appsettings.json dosyasini okumakta ve icerisindeki value lari bizlere getirmektedir dolayisiyla IoC den 
 bu servisi herhangi bir Controller da depedency Injection ile talep edebilir ve appsettings.json dosyasindaki konfigurasyonlari kullanabiliriz*/

// Environment ---> Environment Variable yani env degiskenleri sayesinde biz ASP.Net uygulamamizi olusturdugumuzda calistigi ortami belirleyebiliyoruz ve farkli degiskenler tanimlayabiliyoruz bunlari bu Variablelar ile yapiyoruz
/* Project bolumune sag tiklayip property dedigimizde Debug kismi vardir orada Environment Variables alanina rastlayabiliriz burada name yeridne ASPNETCORE_ENVIRONMENT
value kisminda da Development vardir . iste bizim ortamimiz burasidir Development ortaminda calismaktayiz , eger bu urun tamamlanmak uzere ise Staging , tamamlandi ise Production ortamina dondururuz*/


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

app.Run();

