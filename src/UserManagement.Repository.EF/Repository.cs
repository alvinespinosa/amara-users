using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UserManagement.Repository.EF.Interface;

namespace UserManagement.Repository.EF
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        //private readonly DbSet<T> _dbSet;
        //private readonly IConfiguration _config;

        //public IDbConnection Connection => new SqlConnection(_config.GetConnectionString("MyConnectionString"));

        public Repository(DbContext context)//, DbSet<T> dbSet, IConfiguration config)
        {
            _context = context;
            //_dbSet = dbSet;
            //_config = config;
        }

        public T FindId(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
