using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.Logic.SharedHelper
{
  public  interface ICRUD<T> where T : class 
    {
        Task<IEnumerable<T>> getAllAsync();
        ICollection<T> GetAll(Func<T , bool> Func);

       T Get(int ID);
        bool Update(T Entity);

        bool Remove(T Entity);

        bool Remove(int ID);

        
    }
}
