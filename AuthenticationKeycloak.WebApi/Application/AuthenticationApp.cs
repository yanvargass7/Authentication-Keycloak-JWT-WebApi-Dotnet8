using AuthenticationKeycloak.WebApi.Interfaces;
using AuthenticationKeycloak.WebApi.Models;
using IdentityModel.Client;

namespace AuthenticationKeycloak.WebApi.Application
{
    public class AuthenticationApp : IAuthentication
    {
        private readonly IConfiguration _configuration;

        public AuthenticationApp(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Login(User user)
        {
            var client = new HttpClient();
            var disco = client.GetDiscoveryDocumentAsync("http://localhost:8080/realms/master").GetAwaiter().GetResult();
            if (disco.IsError)
            {
                throw new Exception($"Discovery endpoint error: {disco.Error}");
            }

            var tokenResponse = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "",
                ClientSecret = "",
                UserName = user.UserName,
                Password = user.Password
            }).GetAwaiter().GetResult();

            if (tokenResponse.IsError)
            {
                throw new Exception($"Token request error: {tokenResponse.Error}");
            }

            return tokenResponse.AccessToken;
        }
    }
}
