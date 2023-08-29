using FluentValidation.AspNetCore;
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
    public class Startup
    {
       
           public  void ConfigureServices(IServiceCollection services)
            {
            // ASP.NET CORE uygulamasinda MVC mimarisini kullanabilmek icin controllers ve view yapilanmasini services olarak ekledik . 
            services.AddControllersWithViews().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<Startup>());
            // Fluent Validation kutuphanesini kullanabilmek icin addfluentvalidation yaptik . buradaki callback functionu otomatik olarak ilgili validatorlari gormesi icin yaptik  
            }
           

           public  void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
        
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseRouting(); // Gelen requestin rotasini belirleyen middleware dir .
            app.UseStaticFiles();
                app.UseEndpoints(endpoints => // Endpoint ; Yapilan istegin varis noktasi . URL , istek adresi... Bu da routing gibi middleware dir 
                {
                    //endpoints.MapGet("/", async context =>
                    //{
                    //    await context.Response.WriteAsync("hello world");
                    //});
                    endpoints.MapDefaultControllerRoute();
                    /*
                     MapDefaultControllerRoute endpointinde default olarak {controller=Home}/{action=index}/{id?} formatinda gelmektedir bunun sebebi ise biz isteklerimizi bazi formatlarda gondeririz bunlardan biri;
                    https://www.......com/personal/getir diye aratildiginda gelen istekte personal controllera , getir de actiona karsilik gelir . Bunlar ontanimli parametrelerdir ve suslu parantez icerisinde yazildiginda
                    bu anlasilir. Eger https://www.....net seklide default olarak bir siteye girersek endpoint de controller default olarak Home a , action da index e gider . en sondaki Id yi belirtmek zorunda degiliz
                    yani null olabilir , sonundaki soru isareti(?) bunu belirtmektedir 
                    */
                     
                   
                });
            }
        }
    
}
