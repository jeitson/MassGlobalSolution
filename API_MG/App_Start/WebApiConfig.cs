using API_MG.Infrastructure;
using Library_MG;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API_MG
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Configuración y servicios de API web
            Application.Start();
            config.DependencyResolver = new UnityResolver(Application.Container);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(
               config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml"));
        }
    }
}
