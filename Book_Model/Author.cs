using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
    public class Author
    {

        [Key]
        public int Autor_Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
        [NotMapped]
        public int Age { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    



    }
}
