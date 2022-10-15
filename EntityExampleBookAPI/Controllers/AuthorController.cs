using Book_Model;
using BookDataAccess.Data;
using EntityExampleBookAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EntityExampleBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AuthorController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet("Projections")]
        public IActionResult getProjections()
        {
            var AuthorsNameList = _context.Authors.Select(cust=>new {Name=cust.Name});
            return Ok(AuthorsNameList);
        }
        [HttpGet("ManageBookAutor")]
        public IActionResult ManageBookAutor()
        {
            List<Author> author = new List<Author>();
            AuthorBookResponse authorBookResponse = new AuthorBookResponse();
           // List<BookAuthorDTO> ListbookAuthorDTO= new List<BookAuthorDTO>();
            var bookAutorList=_context.BookAuthors.Include(ba=>ba.Authors).Include(ba=>ba.Books).Where(ba=>ba.Book_Id==12).ToList();
            foreach (var bookAuthor in bookAutorList)
            {
                authorBookResponse.ListOfBookAuthorParticipe.Add(new BookAuthorDTO { Name = bookAuthor.Authors.Name, DOB = bookAuthor.Authors.DOB, Title = bookAuthor.Books.title });
            }
            
            List<int> ListofAuthorParticipe = bookAutorList.Select(u => u.Author_Id).ToList();
            var ListofAuthorNOTParticipe = _context.Authors.Where(u=>!ListofAuthorParticipe.Contains(u.Autor_Id)).ToList();
           // authorBookResponse.ListOfBookAuthorParticipe = ListbookAuthorDTO;
            authorBookResponse.ListOfBookAuthorNotParticipe = ListofAuthorNOTParticipe;




            return Ok(authorBookResponse);
        }
        [HttpPost("ManageBookAutorAddRecord")]
        public IActionResult ManageBookAutorAddRecord()
        {
           BookDetail bookDetail=new BookDetail { NumberOfPage = 150 ,Price=700};
            Publisher publisher = new Publisher { Location = "KL", Name = "SamRan" };
            Author author = new Author { Name = "RanaaaaSam" };
            _context.Add(author);
            _context.SaveChanges();
            Book book = new Book { title = "testCreate33", NumberOfchapters = 10, bookDetail = bookDetail, Publishers = publisher };
            _context.Add(book);
            _context.SaveChanges();
            BookAuthor bookAuthor = new BookAuthor { Book_Id = book.Book_Id, Author_Id = author.Autor_Id };
            _context.Add(bookAuthor);

            _context.SaveChanges();
            return Ok();
           
        }
        [HttpGet("getAutors")]
        public IActionResult getAutors()
        {
            var Authors = _context.Authors.ToList();
            return Ok();
        }
        [HttpPost("addAutors")]
        public IActionResult addAutors(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost("updateAutors")]
        public IActionResult updateAutors(int AuthorID)
        {
            var updatedAuthor = _context.Authors.FirstOrDefault(x => x.Autor_Id == AuthorID);
            updatedAuthor.Name = "title";
            _context.Update(updatedAuthor);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult deleteAutors(int AuthorID)
        {
            var selectedAuthor = _context.Authors.FirstOrDefault(x => x.Autor_Id == AuthorID);
            _context.Remove(selectedAuthor);
            _context.SaveChanges();
            return Ok();
        }
    }
}
