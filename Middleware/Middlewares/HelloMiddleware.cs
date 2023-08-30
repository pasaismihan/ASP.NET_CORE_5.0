using System;
namespace Middleware.Middlewares
{
	public class HelloMiddleware
	{
		RequestDelegate _next;
		public HelloMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		public async Task Invoke(HttpContext httpContext)
		{
			// RequestDelegatein imzasi bu sekilde oldugu icin ayni imzayla yapiyoruz ki kendinden bir sonraki middlewareyi tetiklesin. bu yuzden Invoke metodunu olusturuyoruz
			Console.WriteLine("selam hosgeldiniz");
			await _next.Invoke(httpContext);
			Console.WriteLine("gorusuruz gule gule");
			// bu yaptigimiz costum middlewareyi olusturduktan sonra bunu extension olarak IApplicationBuildera eklememiz lazim ki app. diyerek cagirabilelim...
		}
	}
}

