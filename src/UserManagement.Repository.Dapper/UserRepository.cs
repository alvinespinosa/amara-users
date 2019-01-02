using Amara.Solutions.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UserManagement.Models;

namespace UserManagement.Repository.Dapper
{
    public class UserRepository : IReadOnlyRepository<User>
    {
        public IDbConnection Connection => throw new NotImplementedException();

        public User FindById(string id)
        {
            User user = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                user = cn.Query<User>("SELECT * FROM Users WHERE ID=@ID", new { ID = id }).SingleOrDefault();
            }

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = null;

            using (IDbConnection cn = Connection)
            {
                cn.Open();
                users = cn.Query<User>("SELECT * FROM Users");
            }

            return users;
        }
    }
}
