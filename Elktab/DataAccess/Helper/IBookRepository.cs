using Elktab.Data.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.DataAccess.Helper
{
   public interface IBookRepository : IRepository<Book> 
    {
        new Task<Book> Get(int id);
    }
}
