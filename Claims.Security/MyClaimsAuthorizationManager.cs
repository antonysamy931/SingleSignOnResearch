using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Claims.Security
{
    public class MyClaimsAuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            var resource = context.Resource.FirstOrDefault().Value;
            var action = context.Action.FirstOrDefault().Value;
            switch (resource)
            {
                case "Home":
                    if(action.Equals("View"))
                        return true;
                    else
                        return false;
                default:
                    return false;
            }            
        }
    }
}
