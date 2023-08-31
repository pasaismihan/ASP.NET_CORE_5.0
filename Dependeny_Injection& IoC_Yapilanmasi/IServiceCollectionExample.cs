using System;
using Dependeny_Injection__IoC_Yapilanmasi.Services;

namespace Dependeny_Injection__IoC_Yapilanmasi
{
	public class IServiceCollectionExample
	{
		// BURADA IServiceCollection CALISMA PRENSIBINI ACIKLADIK... 
		public IServiceCollectionExample()
		{
			IServiceCollection services = new ServiceCollection(); // built-in IoC (burada olusturdugumuz IServiceCollection Containerinin aslinda bir IoC yapilanmasi oldugunu gormek)
			services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog()));
			services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog()));

			ServiceProvider provider = services.BuildServiceProvider(); // BuildServiceProvider somut bir container olusturmak demektir artik provider ref kullanarak bu container icerisine ilgili metodlari list generic olarak gonderebiliriz
			provider.GetService<ConsoleLog>();
			provider.GetService<TextLog>(); // burada oldugu gibi generic olarak containera ekliyoruz . IServiceCollection da bu sekilde listelenmis container dir . services diyerek de ilgili containerdan istedigimiz degeri cagiririz
		}
	}
}

