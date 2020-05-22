using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EverestAlbumLibrary
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "producer",
                url: "Producers/{action}/{id}",
                defaults: new { controller = "Producers", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "create-producer",
                url: "Producers/Create/{id}",
                defaults: new { controller = "Producers", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ArtistAlbum",
                url: "ArtistAlbums/{action}/{id}",
                defaults: new { controller = "ArtistAlbums", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "create-artistAlbums",
                url: "ArtistAlbums/Create/{id}",
                defaults: new { controller = "ArtistAlbums", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Artist",
                url: "Artists/{action}/{id}",
                defaults: new { controller = "Artists", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Create_artist",
                url: "Artists/Create/{id}",
                defaults: new { controller = "Artists", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Album",
                url: "Albums/{action}/{id}",
                defaults: new { controller = "Albums", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Create_album",
                url: "Albums/Create/{id}",
                defaults: new { controller = "Albums", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
