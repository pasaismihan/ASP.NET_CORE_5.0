using System;
namespace Costum_Route_Handler.Handler
{
	public class ExampleHandler
	{
	public RequestDelegate Handler()
		{
			return async c =>
			{
				await c.Response.WriteAsync("hello world");
			};
		}
	}
}

