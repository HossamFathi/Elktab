using AutoMapper;
using Elktab.Data.context;
using Elktab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.Logic.SharedHelper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<ImportantTips, ImportantTipsDto>().ReverseMap();
            CreateMap<category, categoryDto>().ReverseMap();
            CreateMap<lessonlearned, lessonlearnedDto>().ReverseMap();
           
        }
    }
}
