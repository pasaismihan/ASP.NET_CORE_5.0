using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProjectEx
{
    public class MvcProject
    {
        public static void Main(string[] arg)
        {
            CreateHostBuilder(arg).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] arg) =>
            Host.CreateDefaultBuilder(arg).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>(); // startup temel konfigurasyon classimizdir 
            });
    }
}