using Elktab.Data;
using Elktab.Data.context;
using Elktab.DataAccess.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.DataAccess
{
    public class BookRepository : GeneralRepository<Book> , IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {

        }

        public new Task<Book> Get(int id)
        {

            return table.Include(b => b.Category).Include(b=>b.lessonslearned).Include(b=>b.ImportantTips).FirstOrDefaultAsync(bo => bo.ID == id);
        }

    }
}
