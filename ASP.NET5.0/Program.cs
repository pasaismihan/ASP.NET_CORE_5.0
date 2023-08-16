// ASP.NET bir web gelistirme mimarisidir
// ASP.NET ve ASP.NET CORE arasindaki en onemli farklar ASP.NET CORE un open source olmasi ve windows disindaki isletim sistemlerinde de calisma imkaninin olmasi . tabi bunlarin yaninda exstra ozellikler vardir bunlar asagidadir
// ASP.NET CORE daha performanslidir , cross platformdur , moduler altyapisi vardir , bagimlilik enjeksiyonu(dependency injection) vardir , asenkron islemler vardir , bakimi kolaydir , razor pages vardir
/* web in temel calisma mantigi ; user(kullanici) client araciligi ile sunucuya request gonderir(client burada browser olabilir userin requesti atabilecegi arac diyebiliriz). Her request gonderdigimiz sitenin bir IP adresi olur
fakat bu IP adresleri yalnizca rakamlardan olustugu icin akilda kalmasi acisindan Domain aliriz ( metinsel adresler). bu domaine istek atariz yani ilgili sunucuya. Bu sunucuyu evde de olusturabiliriz fakat
elektrik gitmesi durumu veya bakim durumlari gibi kisimlarda evde sunucu olusturmak maliyetli olacagi icin Hosting hizmeti veren sirketlere bir miktar odeme yaparak 7/24 bu web sitesinin aktif olmasini saglariz
sunucuya yapilan istek server tarafindan incelenir ve gelen requeste karsilik responce iletir. Bu responcenin icerisinde result vardir yani userin bir islem yapmasina karsilik karsisina cikan sayfadir .*/
// HTTP Protokolu -> client ile server arasindaki iletisimi saglayan protokoldur
// Http fonksiyonlari 9 adettir fakat en cok kullandiklarimiz get , post , put , delete dir .
// bazi sunucu turleri IIS , APACHE , KESTREL(asp.net ile calisabiliyor) , Nginx
// Backend(Server Side) -> algoritmik ve mimarisel kodlarin yazildigi alandir , veritabani islemleri backend de gerceklestirilir ,verinin / bilginin uretildigi yerdir 