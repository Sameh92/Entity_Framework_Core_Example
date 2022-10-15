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
    public class BookDetailController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BookDetailController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet("getBookDetail")]
        public IActionResult getBookDetail()
        {
            var books = _context.BookDetails.ToList();
            return Ok(books);
        }
        [HttpGet("getBookelLazyLoading")]
        public IActionResult getBookelLazyLoading()
        {
            var books = _context.Books.ToList();
            foreach(var obj in books)
            {
                obj.bookDetail = _context.BookDetails.FirstOrDefault(u => u.Id == obj.BookDetail_Id);
            }
            List<BookDto> list = new List<BookDto>();
            foreach (var obj in books)
            {
                list.Add(new BookDto
                { BookDetailId = obj.BookDetail_Id, price = obj.bookDetail.Price, Id = obj.Book_Id, Title = obj.title });
            }
          
            return Ok(list);
        }
        [HttpGet("getBookeExplicitLoading")]
        public IActionResult getBookeExplicitLoading()
        {
            var books = _context.Books.ToList();
            foreach (var obj in books)
            {
                _context.Entry(obj).Reference(u => u.Publishers).Load();
            }
            List<BookDto> list = new List<BookDto>();
            foreach (var obj in books)
            {
                list.Add(new BookDto
                { BookDetailId = obj.BookDetail_Id, price = obj.bookDetail.Price, Id = obj.Book_Id, Title = obj.title });
            }

            return Ok(list);
        }
        [HttpGet("getBookeEagerLoading")]
        public IActionResult getBookeEagerLoading()
        {
            List<Book> books = _context.Books.Include(b => b.bookDetail).ToList();
            List<BookDto> list = new List<BookDto>();
            foreach (var obj in books)
            {
                list.Add(new BookDto
                { BookDetailId = obj.BookDetail_Id, price = obj.bookDetail.Price, Id = obj.Book_Id, Title = obj.title });
            }

            return Ok(list);
        }
        [HttpPost("addBook")]
        public IActionResult addBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost("updateBook")]
        public IActionResult updateBook(int BookId)
        {
            var updatedBook = _context.Books.FirstOrDefault(x => x.Book_Id == BookId);
            updatedBook.title = "title";
            _context.Update(updatedBook);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult deleteBook(int BookId)
        {
            var selectedBook = _context.Books.FirstOrDefault(x => x.Book_Id == BookId);
            _context.Remove(selectedBook);
            _context.SaveChanges();
            return Ok();
        }
    }
}
