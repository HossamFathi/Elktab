using Elktab.Data.context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.Models
{
    public class BookDTO
    {
        public BookDTO()
        {
            ImportantTips = new List<ImportantTipsDto>();
            lessonslearned = new List<lessonlearnedDto>();
            categories = new HashSet<categoryDto>();
        }
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1 ,5 ,ErrorMessage ="Rate Value Must Between 1 and 5 ")]
        public int  Rate { get; set; }
        public categoryDto Category { get; set; }
        [Required (ErrorMessage = "Must choise Level")]
        public LevelEnum Level { get; set; }
        [Required]
        [Display(Name="Category")]
        public int CategoryID { get; set; }
        public string UserID { get; set; }

        public IEnumerable<categoryDto> categories { get; set; }
        [Display(Name= "lesson learned")]
        public List<lessonlearnedDto> lessonslearned { get; set; }
        [Display(Name = "Important Tips")]
        public List<ImportantTipsDto> ImportantTips { get; set; }
    }
}
