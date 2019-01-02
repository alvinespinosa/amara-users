using System.Collections.Generic;
using System.Data;

namespace Amara.Solutions.Models
{
    public interface IReadOnlyRepository<T> where T : class, IEntity
    {
        IDbConnection Connection { get; }

        T FindById(string id);

        IEnumerable<T> GetAll();
    }
}
