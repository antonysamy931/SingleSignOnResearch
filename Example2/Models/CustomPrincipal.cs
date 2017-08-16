using System.Security.Principal;
using System.Security.Claims;
using System.Collections.Generic;


namespace Example2.Models
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity
        {
            get;
            private set;
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public CustomPrincipal(string name, string type)
        {
            this.Identity = new CustomIdentity(name, type);
        }
    }

    public class CustomIdentity : IIdentity
    {

        public CustomIdentity(string name, string type)
        {
            this.AuthenticationType = type;
            this.IsAuthenticated = true;
            this.Name = name;
            this.NameIdentifier = "1";
        }

        public string NameIdentifier
        {
            get;
            set;
        }

        public string AuthenticationType
        {
            get;
            set;
        }

        public bool IsAuthenticated
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class CustomClaimPrincipal
    {
        private string _name = null;
        public CustomClaimPrincipal(string name)
        {
            _name = name;
        }

        private List<Claim> GenerateClaimes()
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, _name));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, "1"));
            claims.Add(new Claim(ClaimTypes.Authentication, "true"));
            claims.Add(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/adminDomains", "adminDomains"));
            return claims;
        }

        private ClaimsIdentity GenerateClaimesIndentity()
        {
            ClaimsIdentity identity = new ClaimsIdentity(GenerateClaimes(), "Forms");
            return identity;
        }

        public ClaimsPrincipal GenerateClaimesPrincipal()
        {
            ClaimsPrincipal principal = new ClaimsPrincipal(GenerateClaimesIndentity());
            return principal;
        }
    }

    public class SampleClaimPrincipal : ClaimsPrincipal
    {
        public override void AddIdentity(ClaimsIdentity identity)
        {
            
            base.AddIdentity(identity);
        }
    }
}