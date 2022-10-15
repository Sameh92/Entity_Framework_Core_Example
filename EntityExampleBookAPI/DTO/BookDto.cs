using Book_Model;
using System;
using System.Collections.Generic;


namespace EntityExampleBookAPI.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int IdPubisher { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int BookDetailId { get; set; }
        public decimal price { get; set; }
        public int NumberOfPage { get; set; }
        public int? NumberOfchapters { get; set; }
        public string NameOFAutor { get; set; }
        public DateTime? DOB { get; set; }

    }
}
