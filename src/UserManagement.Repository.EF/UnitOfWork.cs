using UserManagement.Repository.EF.Data;
using UserManagement.Repository.EF.Interface;

namespace UserManagement.Repository.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly UserContext _context;

        public UnitOfWork()//UserContext context, 
            //IUserRepository users)
        {
            _context = new UserContext();// context;
            Users = new UserRepository(null);
        }

        public IUserRepository Users { get; private set; }

        public void Dispose()
        {
            //_context.Dispose();
        }

        public void Save()
        {
            //_context.SaveChanges();
        }
    }
}
