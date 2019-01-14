using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserManagement.Models;

namespace UserManagement.Repository.EF.Data
{
    public class UserContext : DbContext
    {
        private readonly IConfiguration _config;

        public UserContext(DbContextOptions<UserContext> opt, IConfiguration config)
            : base(opt)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(_config.GetConnectionString("MyConnectionString"));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    => modelBuilder.ApplyConfiguration(new UserConfiguration());

        public virtual DbSet<User> Users { get; set; }
    }
}
