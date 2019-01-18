using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using UserManagement.Models.Entities;
using Microsoft.Extensions.Configuration;
using UserManagement.Repository.Dapper.Interface;

namespace UserManagement.Repository.Dapper
{
    public class UserRepository : IReadOnlyRepository<User>
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("MyConnectionString"));
            }
        }

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
