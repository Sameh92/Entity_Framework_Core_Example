using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
    public  class BookAuthorFluent
    {
        
        public int Book_Id { get; set; }

     
        public int Author_Id { get; set; }

        public BookFluent BookFluent { get; set; }
        public AuthorFlunet AuthorFlunet { get; set; }

    }
}
