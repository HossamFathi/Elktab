using AutoMapper;
using Elktab.Data;
using Elktab.Data.context;
using Elktab.DataAccess.Helper;
using Elktab.Logic.Books.Helper;
using Elktab.Logic.Tips.Helper;
using Elktab.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Elktab.Logic.Books
{
    public class BookLogic : IBook
    {
        private readonly IBookRepository _books;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITips _Tips;
     
     
        public BookLogic(IBookRepository Books , IMapper mapper , IHttpContextAccessor httpContextAccessor /*, ITips Tips*/)
        {

            _books = Books;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            //_Tips = Tips;
        }
        public async Task<BookDTO> Get(int? ID)
        {
            if (ID == null)
                return null;
           var Book = await _books.Get((int)ID);
            return _mapper.Map<BookDTO>(Book) ;
        }

        public async Task<IEnumerable<BookDTO>> getAllAsync()
        {
            var Books =  await _books.GetALl().Include(b => b.Category).ToListAsync();
          
            return _mapper.Map<ICollection<BookDTO>>(Books); 
        }

        public  ICollection<BookDTO> GetAll(Func<BookDTO, bool> Func)
        {

            var Books = _books.GetALl((Func<Book, bool>)Func).Include(b => b.Category).ToList();
            return _mapper.Map<ICollection<BookDTO>>(Books);
        }

        public bool Remove(BookDTO book)
        {
          
           var bookDeleted =  _mapper.Map<Book>(book);
          return  _books.Remove(bookDeleted);
        }

        public bool Remove(int ID)
        {
           return  Remove(Get(ID));
           
        }

        public bool Update(BookDTO Entity)
        {
         var  book  = _mapper.Map<Book>(Entity);
            return  _books.Update(book);
        }

        public BookDTO Get(int ID)
        {
           var book =  _books.Get(ID);
            return _mapper.Map<BookDTO>(book);
             
        }

        public BookDTO Create(BookDTO book )
        {
            var Newbook = _mapper.Map<Book>(book);


              var addedBook =   _books.Add(Newbook);
            if (addedBook == null)
                return null;
            return _mapper.Map<BookDTO>(addedBook);

        }

        private string getUserID() {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
