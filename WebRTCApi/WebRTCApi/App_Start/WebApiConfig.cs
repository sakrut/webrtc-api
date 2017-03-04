using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebRTCApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            BrowserJsonFormatter.SetSettings(config.Formatters.JsonFormatter.SerializerSettings);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

    public class BrowserJsonFormatter : JsonMediaTypeFormatter
    {
        public BrowserJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            SetSettings(this.SerializerSettings);
            //this.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
        }

        public static void SetSettings(JsonSerializerSettings SerializerSettings)
        {
            SerializerSettings.Formatting = Formatting.Indented;
            SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
}
