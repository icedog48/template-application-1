using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin
{
    public static class IAppBuilderExtensions
    {
        public static void ConfigureOAuth(this IAppBuilder app, OAuthAuthorizationServerProvider authorizationServerProvider, string endPoint)
        {
            var autorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString(endPoint),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = authorizationServerProvider
            };

            var bearerAuthenticationOptions = new OAuthBearerAuthenticationOptions();

            app.ConfigureOAuth(autorizationServerOptions, bearerAuthenticationOptions);
        }

        public static void ConfigureOAuth(this IAppBuilder app, OAuthAuthorizationServerOptions autorizationServerOptions, OAuthBearerAuthenticationOptions bearerAuthenticationOptions)
        {
            // Token Generation
            app.UseOAuthAuthorizationServer(autorizationServerOptions);

            app.UseOAuthBearerAuthentication(bearerAuthenticationOptions);
        }
    }
}