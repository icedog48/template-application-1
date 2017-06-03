using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace RestAPI.Infrastructure.OAuth2.ServerProviders
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var username = context.UserName;
            var password = context.Password;

            //this.Usuario = this.usuarioService.Login(username, password);

            //if (this.Usuario == null)
            //{
            //    context.SetError("invalid_grant", "The user name or password is incorrect.");
            //    return;
            //}

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Email, username));

            context.Validated(identity);
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            //context.AdditionalResponseParameters.Add("username", this.Usuario.NomeUsuario);
            //context.AdditionalResponseParameters.Add("AlterarSenha", this.Usuario.AlterarSenha);
            //context.AdditionalResponseParameters.Add("Permissoes", JsonConvert.SerializeObject(this.Usuario.Perfil.Permissoes.Select(x => x.Nome)));

            return base.TokenEndpointResponse(context);
        }
    }
}