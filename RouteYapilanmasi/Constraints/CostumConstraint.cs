using System;

namespace RouteYapilanmasi.Constraints
{
    public class CostumConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            throw new NotImplementedException();
        }
        /* CostumConstraintimizi sistemimize tanitmak icin startup dosyasindaki paketlerden sorumlu metodumuzun icerisine services.Configure<RouteOptions> ........ ekliyoruz veya startup yok ise program.cs icerisine
        builder.Services.Configure<RouteOptions> .......seklinde ekliyoruz */
    }
}

