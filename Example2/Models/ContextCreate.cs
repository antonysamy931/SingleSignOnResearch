using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Example2.Models
{
    public class ContextCreate : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Authentication, Convert.ToString(true)));
                claims.Add(new Claim(ClaimTypes.Name, HttpContext.Current.User.Identity.Name));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, "1"));

                ClaimsIdentity identity = new ClaimsIdentity(claims, "Forms");

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                Thread.CurrentPrincipal = principal;
            }
        }


        public void OnActionExecuting(ActionExecutingContext filterContext)
        {            
        }
    }
}