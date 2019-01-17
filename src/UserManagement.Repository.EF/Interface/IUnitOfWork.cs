using System;

namespace UserManagement.Repository.EF.Interface
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository Users { get; }

        void Save();
    }
}
