using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Threading;
using Example2.Models;
using System.IdentityModel.Services;
using System.Security.Permissions;

namespace Example2.Controllers
{
    [Authorize]    
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [ClaimsPrincipalPermission(SecurityAction.Demand, Operation = "View", Resource = "Home")]
        [HttpGet]
        public ActionResult Index()
        {

            var principal = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var name = principal.Claims.Where(x => x.Type == ClaimTypes.Name).Select(x => x.Value).FirstOrDefault();
            var id = principal.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault();
            var admin = principal.Claims.Where(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/adminDomains").Select(x => x.Value).FirstOrDefault();
            var identity = principal.Identity as ClaimsIdentity;

            return View();
        }

    }
}
