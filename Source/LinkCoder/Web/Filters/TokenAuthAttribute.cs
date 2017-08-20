using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using BusinessLogic.Services.Interfaces;
using Ninject;
using Web.Common;

namespace Web.Filters
{
    public class TokenAuthAttribute : AuthorizeAttribute
    {


        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (Authorize(filterContext))
            {
                return;
            }
            HandleUnauthorizedRequest(filterContext);
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
        }

        private bool Authorize(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Contains("Token"))
            {
                var token = actionContext.Request.Headers.GetValues("Token").First();

                if (!string.IsNullOrEmpty(token) && TokenGenerator.IsTokenValid(token))
                {
                    var userId = TokenGenerator.GetUserNameFromToken(token);
                    var routeData = actionContext.Request.GetRouteData();
                    if (routeData.Values.Keys.Contains("userId") && !routeData.Values["userId"].Equals(userId))
                        return false;

                    return true;
                }
            }
            return false;
        }

    }
}