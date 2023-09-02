using DTO_Yapilari_ViewModel.AutoMappers;

var builder = WebApplication.CreateBuilder(args);

// ViewModel ---> 2 farkli kullanim sekli vardir bunlardan birisi ; Birden fazla Modeli/Degeri/Veriyi tek bir nesne uzerinde birlestirme gorevi goren nesnedir.

// DTO(Data Transfer Object) ---> Bir verinin(genellikle veritabanindan gelen verinin) transfer modellemesidir. View modeldan cok farki vardir bunlardan en temeli ViewModelin yalnizca Modelden View a yapilan transferdir
// DTO herhangi bir fonsiyonellik barindirmaz salt veriyi temsil eder
// Yani DTO dedigimiz yapilanma databaseden gelen verilerin ornegin A,B,C,D entity lerini backende aldik bunlar bir nesne icerisinde . bunlardan sadece A ve C kullanilacaksa onlari bir nesne icerisine alip transferini DTO saglar


/* Sozlesme/Kontrat Mantigi ---> Backend de uretilen bir verinin client a gidecegi haliyle ViewModel da olusturulmasi durumuna o verinin Sozlesmesi denir, yani backend den gelecek olan datayi
 client da karsilayabilmemiz icin kesinlikle o data turunden bir nesne olusturmasi gerekecektir*/

/* Kullanicidan gelen datalari ViewModel ile karsiladiktan sonra bu ViewModel daki verileri veritabanina kaydetmek isteyebiliriz . Bu durumda bu verileri Entity Model e donusturmemiz gerekecektir
bunun icin bazi yontemleri vardir ; Manuel Donusturme , Implicit Operator Overload Ile Donusturme , Explicit Operator Overload Ile Donusturme , Reflection Ile Donusturme ve en populer kutuphane olan
AutoMapper Kutuphanesi Ile Donusturmedir . */


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(PersonelProfil)); // Burada AutoMapper.dependency...... paketini de yukluyoruz ve profili tanimlamak icin burada typeof icerisinde yaziyoruz

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

