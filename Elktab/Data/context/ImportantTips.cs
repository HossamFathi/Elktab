using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elktab.Data.context
{
    public class ImportantTips
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Tips { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}
