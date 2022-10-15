using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
    public  class BookAuthor
    {
        [ForeignKey("Books")]
        public int Book_Id { get; set; }

        [ForeignKey("Authors")]
        public int Author_Id { get; set; }

        public Book Books { get; set; }
        public Author Authors { get; set; }

    }
}
