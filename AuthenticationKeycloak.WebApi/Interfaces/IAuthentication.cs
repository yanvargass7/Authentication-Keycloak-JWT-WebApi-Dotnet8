using AuthenticationKeycloak.WebApi.Models;

namespace AuthenticationKeycloak.WebApi.Interfaces
{
    public interface IAuthentication
    {
        string Login(User user);
    }
}
