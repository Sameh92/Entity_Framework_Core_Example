using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
    public class BookDetail
    {
        public int Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int? NumberOfPage { get; set; }
        public Book book { get; set; }
        
    }
}
