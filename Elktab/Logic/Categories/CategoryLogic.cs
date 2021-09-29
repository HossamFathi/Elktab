using AutoMapper;
using Elktab.Data.context;
using Elktab.DataAccess.Helper;
using Elktab.Logic.Categories.Helper;
using Elktab.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.Logic.Categories
{
    public class CategoryLogic : ICategory
    {
        private readonly IRepository<category> _Category;
        private readonly IMapper _mapper;
        public CategoryLogic(IRepository<category> Category, IMapper mapper)
        {
            _Category = Category;
            _mapper = mapper;
        }
    
        public categoryDto Get(int ID)
        {
            var Category =  _Category.Get(ID);
            return _mapper.Map<categoryDto>(Category);
        }

        public ICollection<categoryDto> GetAll(Func<categoryDto, bool> Func)
        {
            var Categories = _Category.GetALl((Func<category, bool>)Func).Include(C => C.Books).ToList();
            return _mapper.Map<ICollection<categoryDto>>(Categories);
        }
    

        public async Task<IEnumerable<categoryDto>> getAllAsync()
        {
            var Categories = await _Category.GetALl().Include(c => c.Books).ToListAsync();

            return _mapper.Map<ICollection<categoryDto>>(Categories);
        }

        public bool Remove(categoryDto Entity)
        {
            var CategoryDeleted = _mapper.Map<category>(Entity);
            return _Category.Remove(CategoryDeleted);
        }

        public bool Remove(int ID)
        {
            return Remove(Get(ID));
        }

        public bool Update(categoryDto Entity)
        {
            var Category = _mapper.Map<category>(Entity);
            return _Category.Update(Category);
        }
    }
}
