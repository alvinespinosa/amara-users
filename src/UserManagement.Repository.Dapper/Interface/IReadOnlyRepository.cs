using System.Collections.Generic;
using System.Data;

namespace UserManagement.Repository.Dapper.Interface
{
    public interface IReadOnlyRepository<T> where T : class
    {
        IDbConnection Connection { get; }

        T FindById(string id);

        IEnumerable<T> GetAll();
    }
}
