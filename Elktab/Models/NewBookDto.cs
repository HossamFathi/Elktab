using Elktab.Data.context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.Models
{
    public class NewBookDto
    {
        public NewBookDto()
        {
            ImportantTips = new HashSet<ImportantTipsDto>();
            lessonslearned = new HashSet<lessonlearnedDto>();
            categories = new HashSet<categoryDto>();
        }
     
        [Required]
        [Range(1, 5, ErrorMessage = "Rate of Book between 1 and 5 ")]
        [Display(Name = "Book Rate")]
        public int Rate { get; set; }
       
        [Display(Name = "Book Level ")]
        public LevelEnum Level { get; set; }
        
        public int CategoryID { get; set; }
        public string UserID { get; set; }


        public ICollection<categoryDto> categories { get; set; }
        public ICollection<lessonlearnedDto> lessonslearned { get; set; }
        public ICollection<ImportantTipsDto> ImportantTips { get; set; }
    }
}
