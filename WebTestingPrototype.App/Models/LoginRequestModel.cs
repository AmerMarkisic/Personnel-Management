using System.ComponentModel.DataAnnotations;

namespace WebTestingPrototype.App.Models
{
    public class LoginRequestModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}