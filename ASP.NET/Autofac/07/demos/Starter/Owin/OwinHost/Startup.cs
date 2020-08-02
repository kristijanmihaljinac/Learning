using Owin;
using System;
using System.Linq;
using System.Web.Http;

namespace OwinHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            appBuilder
                .Use<LoggerMiddleware>()
                .UseWebApi(config);
        }
    }
}
