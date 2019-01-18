using System.Collections.Generic;
using UserManagement.Models.Entities;

namespace Amara.UserManagement.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUser();
        User GetUserById(string id);
        bool UpdateUser(string id, User user);
    }
}
