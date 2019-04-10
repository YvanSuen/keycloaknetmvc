
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Owin.Security.Keycloak;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.Jwt;
using System.IdentityModel.Tokens.Jwt;

[assembly: OwinStartup(typeof(KeycloakOwinAuthenticationSample.Startup))]

namespace KeycloakOwinAuthenticationSample
{
    public class Startup
    {
       
        public void Configuration(IAppBuilder app)
        {
           
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = "admin-cli",
                    ClientSecret = "481f0a25-c601-48d5-8b05-30de4ea44d19",
                    Authority = "http://192.168.115.19:8080/auth/realms/master",
                    ResponseType = OpenIdConnectResponseType.CodeIdToken,
                    RequireHttpsMetadata = false,
                    RedirectUri = "http://localhost:53145"

                });
          
        }
    }
}