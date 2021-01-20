using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebTestingPrototype.App.Entities;
using WebTestingPrototype.App.Helpers;
using WebTestingPrototype.App.Models;

namespace WebTestingPrototype.App.Services.UserService
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>()
        {
            new User {Id = 1, FirstName = "Max", LastName = "Mustermann", UserName = "admin", Password = "admin"}
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        
        
        public LoginResponseModel Authenticate(LoginRequestModel model)
        {
            var user = _users.SingleOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            if (user == null) return null;

            var token = GenerateJwtToken(user);
            return new LoginResponseModel(user, token);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}