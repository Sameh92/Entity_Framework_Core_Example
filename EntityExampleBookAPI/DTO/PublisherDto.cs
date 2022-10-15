using System.Collections.Generic;

namespace EntityExampleBookAPI.DTO
{
    public class PublisherDto
    {
        public int IdPubisher { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<BookDto>  booksDto { get; set; }
    }
}
