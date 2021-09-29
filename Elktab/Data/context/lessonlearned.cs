using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.Data.context
{
    public class lessonlearned
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Description " )]
        public string Description { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}
