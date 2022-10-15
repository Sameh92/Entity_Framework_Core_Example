using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
    public class Publisher
    {
        [Key]
        public int Id_Pubisher { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        
        public List<Book> Books { get;set; }
      
    }
}
