using System.Collections.Generic;
using UserManagement.Models;

namespace Amara.UserManagement.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUser();
        User GetUserById(string id);
        void UpdateUser(string id, User user);
    }
}
