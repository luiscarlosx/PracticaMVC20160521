using System.Web.Mvc;
using System.Web.Routing;

namespace TiendaMusica.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //routes.MapRoute(
            //    name:"Artista",
            //    url: "tienda/{artista}/{action}",
            //    defaults: new { controller="Artistas", action="Perfil"}
            //    );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "Admin/{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
               name: "Default3",
                url: "Admin/{nombre}/{album}/{action}",
               defaults: new { controller = "Album",  action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                "Default2",                                              // Route name
                "Tienda/{artista}",                           // URL with parameters
                new { controller = "Artistas", action = "Albums", id = "" }  // Parameter defaults
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{artista}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );



        }
    }
}
