using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Web.Http.Cors;
using LaunchPad.Infrastructure.MessageHandlers;
using LaunchPad.Data.Repositories;

namespace LaunchPad
{
    public static class WebApiConfig
    {
        private static string GetAllowedOrigins()
        {
            var repo = new SecurityRepository();
            return repo.GetDomains();
        }
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            //config.SuppressDefaultHostAuthentication();
           // config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.MessageHandlers.Add(new LPAuthHandler());
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            string origins = GetAllowedOrigins();
            //string origins = "http://localhost:2500";
            var cors = new EnableCorsAttribute(origins, "Origin, X-Requested-With, Content-Type, Accept, Authorization", "*", "*");
            cors.SupportsCredentials = true;
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
