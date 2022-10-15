using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
    public class BookDetailFluent
    {
        public int Id_BookDetailFluent { get; set; }
        
        public string Price { get; set; }
        public int? NumberOfPage { get; set; }
        public BookFluent BookFluent { get; set; }
        
    }
}
