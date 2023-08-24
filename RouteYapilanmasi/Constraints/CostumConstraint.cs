using System;

namespace RouteYapilanmasi.Constraints
{
    public class CostumConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var Idvalue = values[routeKey];
            return true;
            // ilgili id degerini burada yakalayabiliriz...
        }
        /* CostumConstraintimizi sistemimize tanitmak icin startup dosyasindaki paketlerden sorumlu metodumuzun icerisine services.Configure<RouteOptions> ........ ekliyoruz veya startup yok ise program.cs icerisine
        builder.Services.Configure<RouteOptions> .......seklinde ekliyoruz */
    }
}

/* bu sekilde costum constraint tanimladigimizda ornegin {id:custom} yapabiliriz program.cs tarafinda configuresini o sekilde yaptik . Bu durumda id ye istedigimiz costum ozelligi verebiliriz
 rotamiz ilgili controller ve actiona gelmeden once bu kisima duser, middleware veya filtre gibi dusunebiliriz . */