using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.DataAccess.Helper
{
    public interface IRepository<T> : IDisposable where T : class
    {
        bool SaveChange();
        T Add(T Entity);
        bool AddRange(ICollection<T> Entity);

        T AddWithoutSave(T Enitity);
        bool Update(T Entity);
        bool UpdateWithoutSave(T Entity);

        T Get(int id);
        T Get(string id);
        IQueryable<T> GetALl();
        IQueryable<T> GetALl(Func<T, bool> condition);
        bool Remove(T entity);

    }
}
