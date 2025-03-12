using GamingReport.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GamingReport.Core._Game;

namespace GamingReport.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(string id)
        {
            return _dbSet.Find(id);
        }

        public T GetByName(string name)
        {
            return _dbSet.FirstOrDefault(e => EF.Property<string>(e, "Name") == name);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> GetByCondition(object t, Expression<Func<T, bool>> condition, bool disableLazyLoading = false)
        {
            // var query = _dbSet.AsQueryable();
            //
            // if (disableLazyLoading)
            // {
            //     query = query.AsNoTracking().Include(x => x.Game);
            // }

            _dbSet.Include(x => x == t);
        }
    }
}
