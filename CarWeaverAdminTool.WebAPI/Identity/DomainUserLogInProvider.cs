using System.DirectoryServices.AccountManagement;
using System.Security.Claims;

namespace CarWeaverAdminTool.WebAPI.Identity
{
    public class DomainUserLogInProvider : ILoginProvider
    {
        private readonly string _domain;
        public DomainUserLogInProvider(string domain)
        {
            _domain = domain;
        }

        public bool ValidateCredentials(string userName, string password, out ClaimsIdentity identity)
        {
            using (var principalContext = new PrincipalContext(ContextType.Domain, _domain))
            {
                bool isValid = principalContext.ValidateCredentials(userName, password);
                if(isValid)
                {
                    identity = new ClaimsIdentity(Startup.OAuthOptions.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, userName));
                }
                else
                {
                    identity = null;
                }
                return isValid;
                
            }
        }
    }
}