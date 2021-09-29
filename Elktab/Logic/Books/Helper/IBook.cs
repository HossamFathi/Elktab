using Elktab.Data.context;
using Elktab.Logic.SharedHelper;
using Elktab.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.Logic.Books.Helper
{
    public interface IBook : ICRUD<BookDTO>
    {

         Task<BookDTO> Get(int? ID);
        BookDTO Create(BookDTO book);
    }
}
