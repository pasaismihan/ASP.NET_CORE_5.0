// ASP.NET bir web gelistirme mimarisidir
// ASP.NET ve ASP.NET CORE arasindaki en onemli farklar ASP.NET CORE un open source olmasi ve windows disindaki isletim sistemlerinde de calisma imkaninin olmasi . tabi bunlarin yaninda exstra ozellikler vardir bunlar asagidadir
// ASP.NET CORE daha performanslidir , cross platformdur , moduler altyapisi vardir , bagimlilik enjeksiyonu(dependency injection) vardir , asenkron islemler vardir , bakimi kolaydir , razor pages vardir
/* web in temel calisma mantigi ; user(kullanici) client araciligi ile sunucuya request gonderir(client burada browser olabilir userin requesti atabilecegi arac diyebiliriz). Her request gonderdigimiz sitenin bir IP adresi olur
fakat bu IP adresleri yalnizca rakamlardan olustugu icin akilda kalmasi acisindan Domain aliriz ( metinsel adresler). bu domaine istek atariz yani ilgili sunucuya. Bu sunucuyu evde de olusturabiliriz fakat
elektrik gitmesi durumu veya bakim durumlari gibi kisimlarda evde sunucu olusturmak maliyetli olacagi icin Hosting hizmeti veren sirketlere bir miktar odeme yaparak 7/24 bu web sitesinin aktif olmasini saglariz
sunucuya yapilan istek server tarafindan incelenir ve gelen requeste karsilik responce iletir. Bu responcenin icerisinde result vardir yani userin bir islem yapmasina karsilik karsisina cikan sayfadir .*/
// HTTP Protokolu -> client ile server arasindaki iletisimi saglayan protokoldur
// Http fonksiyonlari 9 adettir fakat en cok kullandiklarimiz get , post , put , delete dir.
// bazi sunucu turleri IIS , APACHE , KESTREL(asp.net ile calisabiliyor) , Nginx
// Backend(Server Side) -> algoritmik ve mimarisel kodlarin yazildigi alandir , veritabani islemleri backend de gerceklestirilir ,verinin / bilginin uretildigi yerdir.
// MVC Yaklasimi --> Model-View-Controller kelimelerinin birlesimidir . MVC patternini kullanan bir yaklasimdir . dizayn patterndir.
/* MVC GIRIS 
    - MVC birbirinden bagimsiz 3 katmani ele alan architectural patterndir .
    - Ozunde Observer , Decorator gibi design patternlari kullanan bir mimarisel desendir
    - Microsoft bu desen uzerine oturtulmus ASP.NET CORE MVC mimarisini gelistirmistir

MVC KATMANLARI
    - Model = Islenecek olan veriyi temsil eden katmandir, genellikle veritabani islemlerinin yapildigi katmandir . Entitiy Framework Core , Entity Models , ADO.NET ,Repository ,Veritabani islemlerinde kullanilir.
    - View = Istek neticesinde elde edilen verileri gorsellestirebilecek , gorsel ciktisini verecek katmandir .bu katmanda render edilir . HTML , CSS , Javascript , Razor , Resim , Muzik , Video
    - Controller = Gelen requestleri karsilayacak olan ve requestin icerigine gore gerekli model islemlerini ustlenecek olan katmandir . Algoritmalari, servisleri, veritabanlarini vs cagirarak/calistirarak/sorgulayarak
istenilen veriyi uretmekten ve ihtiyac dahilinde uretilen bu veriyi View ile gorsellestirmekten sorumludur. Istek neticesinde elde edilen ve islenen veriyi tekrar clienta response olarak dondurur
!! Genel isleyis mantigi ise ; client controlllera request gonderir , bu request dogrultusunda controller model katmanindan datayi uretmesini ister ve datayi modelden alir . Ihtiyac dahilinde view a datayi iletir
iletilen data view da gorsellestirilerek tekrar controllera geri gonderilir daha sonra olusan responceyi controller clienta iletir yani client ile iletisim tamamen controller ile olur

ASP.NET CORE MVC PIPELINE(MVC ISLEYISI)
Request ---> Kestrel(sunucu) ---> Middleware(eger varsa) ---> Routing(gelen istegin turune bakiyor ve endpointe gore ayiriyor) ---> Controller Initialization(MVC deki C dir, routingin ayirdigi turu ele alir ilgili yere gonderir , classdir)
Action Method Execution(Contollerin iletmis oldugu gorevi yapan metotdur aksiyon alma kismidir) ---> Result Execution ( olusan metotlardan sonraki tamamlanmis kisimdir eger gerekiyorsa buradan view katmanina gider)
View Rendering (burada gerekli gorsel islemler yapilir ve hazir olarak tekrar controller a iletilir.  












*/