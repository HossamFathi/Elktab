using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.Data.context
{
    public class category
    {   [Key]
        public int ID { get; set; }
        [Required] 
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
