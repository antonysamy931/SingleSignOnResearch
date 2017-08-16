using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.Mvc3;
using System.Security;
using System.Web;
using System.Web.Security;
using System.Threading;
using Example2.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System;

namespace Example2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IUnityContainer container = new UnityContainer().LoadConfiguration();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public override void Init()
        {
            this.PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;            
        }

        void MvcApplication_PostAuthenticateRequest(object sender, System.EventArgs e)
        {
            if (Request.IsAuthenticated)
            {                
                CustomClaimPrincipal principal = new CustomClaimPrincipal(User.Identity.Name);                
                Context.User = Thread.CurrentPrincipal = principal.GenerateClaimesPrincipal();
            }
        }
    }
}