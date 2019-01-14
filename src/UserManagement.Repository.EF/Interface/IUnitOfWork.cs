using Amara.Solutions.Models;
using System;
using UserManagement.Models;

namespace UserManagement.Repository.EF.Interface
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }

        void Save();
    }
}
