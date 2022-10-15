using Book_Model;
using System;
using System.Collections.Generic;

namespace EntityExampleBookAPI.DTO
{
    public class BookAuthorDTO
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public DateTime? DOB { get; set; }
  
    }
    public class AuthorBookResponse
    {
        public List<BookAuthorDTO> ListOfBookAuthorParticipe { get; set; }=new List<BookAuthorDTO>();
        public List<Author> ListOfBookAuthorNotParticipe { get; set; }
 
    }
}
