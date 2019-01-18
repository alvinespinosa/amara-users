using Microsoft.EntityFrameworkCore;
using UserManagement.Models.Entities;

namespace UserManagement.Repository.EF.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt)
            : base(opt)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }        

        public virtual DbSet<User> Users { get; set; }
    }
}
