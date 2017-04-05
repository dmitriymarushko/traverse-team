namespace Juice.Web.Helpers
{
    using System.Security.Claims;
    using System.Security.Principal;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using Models;

    public class SignInHelper
    {
        private readonly IAuthenticationManager authenticationManager;

        public SignInHelper(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        public void SignIn(LoginViewModel logOn, bool isPersistent)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);

            var identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(ClaimTypes.Email, logOn.Email));
            identity.AddClaim(new Claim(ClaimTypes.Name, logOn.Email));

            if (logOn.RememberMe)
            {
                var rememberBrowserIdentity =
                    authenticationManager.CreateTwoFactorRememberBrowserIdentity(logOn.Email);

                authenticationManager.SignIn(
                    new AuthenticationProperties { IsPersistent = isPersistent },
                    identity,
                    rememberBrowserIdentity);
            }
            else
            {
                authenticationManager.SignIn(
                    new AuthenticationProperties { IsPersistent = isPersistent },
                    identity);
            }
        }

        public void SignOut()
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //authenticationManager.SignOut();
        }
    }
}

