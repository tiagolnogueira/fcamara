using FCamara.WebApi.Models;
using FCamara.WebApi.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FCamara.WebApi.Filters
{
    public class Autenticacao : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                var usuario = ValidarToken(authToken);
                if (usuario != null && usuario.Id > 0 && actionContext.Request.Headers.Authorization.Scheme == "Bearer")
                {
                    HttpContext.Current.User = new GenericPrincipal(new ApiIdentity(usuario.Id, usuario.Login), new string[] { });
                    base.OnActionExecuting(actionContext);
                }
                else
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
        }

        private Usuario ValidarToken(string token)
        {
            
            var simplePrinciple = JwtManager.GetPrincipal(token);
            if (simplePrinciple == null) return null;

            var identity = simplePrinciple.Identity as ClaimsIdentity;
            if (identity == null && !identity.IsAuthenticated)            
                return null;            
            
            var userId = identity.FindFirst(ClaimTypes.PrimarySid);
            var name = identity.FindFirst(ClaimTypes.Name);

            if (!string.IsNullOrWhiteSpace(userId.Value))
                return new Usuario() { Id = Convert.ToInt32(userId.Value), Login = name.Value };
            
            return null;
        }


    }
}