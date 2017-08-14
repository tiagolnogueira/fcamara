using FCamara.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace FCamara.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfiguracaoIoC<WebApiApplication>.Instancia.RegistrarDependencias();
            GlobalConfiguration.Configuration.DependencyResolver = ConfiguracaoIoC<WebApiApplication>.Instancia.WebApiDependencyResolver;

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains(CorsHandler.Origin) && Request.HttpMethod == "OPTIONS")
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                Response.Headers.Add(CorsHandler.AccessControlAllowCredentials, "true");
                Response.Headers.Add(CorsHandler.AccessControlAllowOrigin, Request.Headers.GetValues("Origin").First());
                string accessControlRequestMethod = Request.Headers.GetValues(CorsHandler.AccessControlRequestMethod).FirstOrDefault();
                if (accessControlRequestMethod != null)
                {
                    Response.Headers.Add(CorsHandler.AccessControlAllowMethods, accessControlRequestMethod);
                }
                var hdrs = Request.Headers.GetValues(CorsHandler.AccessControlRequestHeaders).ToList();
                hdrs.Add("X-Auth-Token");
                string requestedHeaders = string.Join(", ", hdrs.ToArray());
                Response.Headers.Add(CorsHandler.AccessControlAllowHeaders, requestedHeaders);
                Response.Headers.Add("Access-Control-Expose-Headers", "X-Auth-Token");
                Response.Flush();
            }
        }

        public static class CorsHandler
        {
            public const string Origin = "Origin";
            public const string AccessControlRequestMethod = "Access-Control-Request-Method";
            public const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
            public const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
            public const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
            public const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";
            public const string AccessControlAllowCredentials = "Access-Control-Allow-Credentials";
        }
    }
}
