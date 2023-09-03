var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


/* Biz bazi verileri deploy etmek istemeyiz bu tur veriler Token , connection string , google , youtube gibi thirtd party authentication tokenlari appsettings.json yerine 
secret manager tools da saklariz .Bu deploy edilmeyen degerlerin kullanilmasini da Environment ile saglariz ilgili ortama ozgu bazi kullanim alanlari veririz.  */
// Bu guvenlik gerektiren veriler developer ortaminda kullanilirken production ortamina cikarildiginda gorunmemesi saglanir ki kotu nitetli kisiler tarafindan farkedilmesin

// secret.json dosyasi projemize sag tiklayip manage user secret dedigimizde cikiyor , dosyaya yine IConfiguration interfacesini kullanarak ulasiyoruz , Option Patterni de ayni sekilde kullanabiliyoruz
// IConfiguration davranisinda once Environment a sonra secret.json a en son da appsettings.json a bakar.
// Ilgili projeyi hazir hale getirmek ve canliya cikarmak istiyorsak proje sag click publish yapiyoruz, burada seceneklerimizde ya folder olarak bilgisayarimiza cikariyoruz , ya bulut olara azure vs. yada docker gibi sanal makinelere de cikarabiliyoruz

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

