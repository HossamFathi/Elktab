using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Elktab.Data.context
{
    public class Book
    {
        public Book()
        {
            ImportantTips = new HashSet<ImportantTips>();
            lessonslearned = new HashSet<lessonlearned>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1 , 5 , ErrorMessage ="Rate of Book between 1 and 5 ") ]
        [Display(Name ="Book Rate")]
        public int Rate { get; set; }
        public ICollection<lessonlearned> lessonslearned {get; set; }
        public ICollection<ImportantTips> ImportantTips { get; set; }
        [Display(Name = "Book Level ")]
        public LevelEnum Level  { get; set; }
        public category Category { get; set; }
        public int  CategoryID { get; set; }
        public string UserID { get; set; }



       
    }

   public enum LevelEnum { 
        Entry ,
       Beginning ,
        medium,
        Advanced
    }
}
