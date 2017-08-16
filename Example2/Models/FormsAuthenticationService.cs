using System.Web.Security;

namespace Example2.Models
{
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool persistanceCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, persistanceCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}