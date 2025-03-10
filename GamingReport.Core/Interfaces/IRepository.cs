using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GamingReport.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public void Add(T entity);

        public void Update(T entity);

        public void Delete(T entity);

        public T GetById(string id);

        public T GetByName(string name);

        public IEnumerable<T> GetAll();

        public IEnumerable<T> GetByCondition(Func<T, bool> condition);
    }
}