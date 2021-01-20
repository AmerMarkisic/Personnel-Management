using System.Collections;
using System.Collections.Generic;
using WebTestingPrototype.App.Entities;
using WebTestingPrototype.App.Models;

namespace WebTestingPrototype.App.Services.UserService
{
    public interface IUserService
    {
        LoginResponseModel Authenticate(LoginRequestModel model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}