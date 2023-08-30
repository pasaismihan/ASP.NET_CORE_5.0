using System;
using Middleware.Middlewares;

namespace Middleware.Extensions
{
	public static class Extension
	{
	public static IApplicationBuilder UseSelam( this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<HelloMiddleware>();
		}
	}
}

