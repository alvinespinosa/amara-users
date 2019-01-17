using UserManagement.Repository.EF.Data;
using UserManagement.Repository.EF.Interface;

namespace UserManagement.Repository.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserContext _context;

        public UnitOfWork(UserContext context, 
            IUserRepository users)
        {
            _context = context;
            Users = users;// new UserRepository(context);
        }

        public IUserRepository Users { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
