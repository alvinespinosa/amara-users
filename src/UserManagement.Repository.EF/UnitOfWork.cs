using System.Data.Entity;
using Amara.Solutions.Models;
using UserManagement.Models;

namespace UserManagement.Repository.EF
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        private readonly Repository<User> _userRepository;

        public DbSet<User> Users { get; set; }

        public UnitOfWork()
        {
            _userRepository = new Repository<User>(Users);
        }

        public IRepository<User> UserRepository
        {
            get { return _userRepository; }
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
