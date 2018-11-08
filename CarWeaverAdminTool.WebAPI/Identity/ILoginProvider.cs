using System.Security.Claims;

namespace CarWeaverAdminTool.WebAPI.Identity
{
    public interface ILoginProvider
    {
        bool ValidateCredentials(string userName, string password, out ClaimsIdentity identity);
    }
}
