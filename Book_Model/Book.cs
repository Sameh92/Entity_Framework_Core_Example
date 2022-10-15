using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Model
{
  //  [Table("samehTable")]
    public class Book
    {
        [Key]
        public int Book_Id { get; set; }
    //    [Column("sameh")]
        [Required]
        public string title { get; set; }

        public int? NumberOfchapters { get; set; }



        [ForeignKey("bookDetail")]
        public int BookDetail_Id { get; set; }
        public BookDetail bookDetail { get; set; }

        [ForeignKey("Publishers")]
        public int Publishers_Id { get; set; }
        public Publisher Publishers { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }


    }
}
