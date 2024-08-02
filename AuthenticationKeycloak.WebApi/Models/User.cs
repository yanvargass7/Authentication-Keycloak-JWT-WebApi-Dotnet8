using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AuthenticationKeycloak.WebApi.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
