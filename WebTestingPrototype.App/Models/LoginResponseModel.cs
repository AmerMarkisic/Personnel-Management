using WebTestingPrototype.App.Entities;

namespace WebTestingPrototype.App.Models
{
    public class LoginResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

        public LoginResponseModel(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Token = token;
        }
    }
}