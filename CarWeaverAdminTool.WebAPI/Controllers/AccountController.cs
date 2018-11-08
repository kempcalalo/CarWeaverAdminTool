using CarWeaverAdminTool.WebAPI.Extensions;
using CarWeaverAdminTool.WebAPI.Identity;
using CarWeaverAdminTool.WebAPI.ViewModels;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace CarWeaverAdminTool.WebAPI.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly ILoginProvider _loginProvider;
        public AccountController(ILoginProvider loginProvider)
        {
            _loginProvider = loginProvider;
        }

        [HttpPost, Route("Token")]
        public IHttpActionResult Token(LogInViewModel login)
        {
            if(!ModelState.IsValid)
            {
                return this.BadRequestError(ModelState);
            }

            ClaimsIdentity identity;

            if(!_loginProvider.ValidateCredentials(login.UserName, login.Password, out identity))
            {
                return BadRequest("Incorrect username or password");
            }

            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));

            return Ok(new LoginAccessViewModel
            {
                UserName = login.UserName,
                AccessToken = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket)
            });
        }
      
    }
}
