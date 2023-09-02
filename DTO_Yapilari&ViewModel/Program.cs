var builder = WebApplication.CreateBuilder(args);

// ViewModel ---> 2 farkli kullanim sekli vardir bunlardan birisi ; Birden fazla Modeli/Degeri/Veriyi tek bir nesne uzerinde birlestirme gorevi goren nesnedir.

// DTO(Data Transfer Object) ---> Bir verinin(genellikle veritabanindan gelen verinin) transfer modellemesidir. View modeldan cok farki vardir bunlardan en temeli ViewModelin yalnizca Modelden View a yapilan transferdir
// DTO herhangi bir fonsiyonellik barindirmaz salt veriyi temsil eder
// Yani DTO dedigimiz yapilanma databaseden gelen verilerin ornegin A,B,C,D entity lerini backende aldik bunlar bir nesne icerisinde . bunlardan sadece A ve C kullanilacaksa onlari bir nesne icerisine alip transferini DTO saglar


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

