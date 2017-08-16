using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.Models
{
    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool persistanceCookie);
        void SignOut();
    }
}
