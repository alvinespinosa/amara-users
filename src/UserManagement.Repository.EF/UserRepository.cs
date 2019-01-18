using UserManagement.Models.Entities;
using UserManagement.Repository.EF.Data;
using UserManagement.Repository.EF.Interface;

namespace UserManagement.Repository.EF
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UserContext context)
            : base(context)
        {

        }

        //public IEnumerable<User> GetUsers(int pageIndex, int pageSize)
        //{
        //    return UserContext.Users
        //        .Include()
        //        .Orderby()
        //        .Skip((pageIndex - 1) * pageSize)
        //        .take(pageSize)
        //        .tolist();
        //}

        //public UserContext _userContext
        //{
        //    get { return context as UserContext; }
        //}
    }
}
