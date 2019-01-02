using Amara.Solutions.Models;
using System;

namespace UserManagement.Models
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<User> UserRepository { get; }

        void Save();
    }
}
