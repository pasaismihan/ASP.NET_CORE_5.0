using Dependeny_Injection__IoC_Yapilanmasi.Services;
using Dependeny_Injection__IoC_Yapilanmasi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog()));
// builder.Services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog())); // bu siniflari eger containera Add metodu ile ekliyorsak default olarak Singleton davranisini sergiler .

// Yukarida kullanilan Add parametresi oldukca ugrastiricidir bunun yerine AddSingleton , AddScoped , AddTransient metodlari vardir bunu asagida kullanacagiz

builder.Services.AddSingleton<ConsoleLog>(); // Eger ConsoleLog sinifimizin costructoru parametresiz ise bunu yapabiliriz fakat parametreli ise bu ise yaramaz alttakini kullanmamiz gerekir
builder.Services.AddSingleton<ConsoleLog>(p=>new ConsoleLog(5)); //parametreli oldugunda bir fonksiyon dondurmemizi istiyor bu yuzden p=> diyerek parametreli yeni bir nesne olusturduk
builder.Services.AddScoped<ConsoleLog>();
builder.Services.AddScoped<ConsoleLog>(p => new ConsoleLog(5));
builder.Services.AddTransient<ConsoleLog>();
builder.Services.AddTransient<ConsoleLog>(p => new ConsoleLog(5));

builder.Services.AddScoped<Ilog>(p => new TextLog()); // bu sekilde yaptigimizda Ilog interfacesinden kalitim aldigi icin dependency injection uygulamis oluyoruz burada degisiklik yapmak istedigimizde sadece
                                                                // yeni instance olusturma kisminda new ConsoleLog() diye degistirmemiz yeterli olacaktir , ayni sekilde parametre kullanacak isek onu da belirtebiliriz
builder.Services.AddScoped<Ilog, ConsoleLog>(); // bu da ustteki ornegin bir farkli kullanim cesididir , tek tek siniflari kullanmak yerine ortak kalitim aldiklari interfaceyi kullanmak cok daha dogrudur



var app = builder.Build();

/* Dependency Injection ---> SOLID prensiplerinden sonuncusu olan Dependency Inversion in somut olarak pratikte gosterilmis hali Dependency Injection Design Pattern idir. Anlami da baglilik olusturmanin
tersine hareket ederek baglilik olusturacak parcalarin ayrilip disaridan projeye enjekte edilmesi durumuna denir. */

/* Baglilik konusunu acarsak ornegin elimizde 2 sinif var A ve B siniflari , A sinifi icerisinde B den instance olusturmak istedigimizde new B(); yapariz. Bu durumda A yi B ye baglamis oluruz cunku
B classinin costructorunda degisiklik yaparsak bunu olusturdugumuz objectte de belirtmemiz gerekir yoksa patlariz . Bu bagliligi ortadan kaldirmak icin Dependency Injection kullaniriz */

/* Temel anlamda Dependency Injection yapmak icin siniflar arasinda bagliligi engelleriz bunun icin de ornegin A , B , C , D olarak 4 sinifimiz olsun . bu siniflar icin bir interface olustururuz ornegin IClass adinda
tum classlara kalitim verir . boylelikle IClass interfacesini kullanarak parametre uzerinden (IClass obj) istedigimiz class a ait ozellikleri cagirabiliriz. */

// IoC (Inversion Of Control) ---> Bir cesit container dir . Dependency Injection yapacagimiz tum degerler/nesneler IoC Container dedigimiz bir sinifta tutulur.
// Asp.NET Core da IoC yapilanmalarini saglayan third party frameworklar mevcuttur bunlardan en populer olanlari ; Structuremap , AutoFac , Ninject
/* Built-in IoC Container icerisine konulacak degerleri nesneleri uc farkli davranisla alabilmektedir ;
        Singleton ---> Uygulama bazli tekil nesne olusturur. Tum taleplere o nesneyi gonderen davranis bicimidir .
        Scoped ---> Her request basina bir nesne uretir ve o request pipeline inde olan tum isteklere o nesneyi gonderir, yani singletondan farki orada requestler arasi fark yoktu direkt olarak urettigi tekil nesneyi iletiyordu
        Transient ---> Her requestin her bir talebine karsilik bir nesne uretir ve gonderir , en maliyetli olan transient davranistir
*/

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

