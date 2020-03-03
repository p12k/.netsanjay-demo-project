using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsModels.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
        IEnumerable<T> Table { get; }
        //void Save(T entity);
        T Foreign(T entity);
    }
}
