using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
  
    public class BookFluent
    {
       
        public int Book_Id_Flent { get; set; } 
        public string Title { get; set; } 
        public int BookDetail_Id { get; set; }
        public BookDetailFluent BookDetailFluent { get; set; }    
        public int Publishers_Id { get; set; }
        public PublisherFluent PublisherFluent { get; set; }
        public ICollection<BookAuthorFluent> BookAuthorFluent { get; set; }


    }
}
