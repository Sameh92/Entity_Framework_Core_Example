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
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet("getBook")]
        public IActionResult getBook()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }
        [HttpGet("getBookelLazyLoading")]
        public IActionResult getBookelLazyLoading()
        {
            var books = _context.Books.ToList();
            foreach(var obj in books)
            {
                obj.Publishers = _context.Publisher.FirstOrDefault(u => u.Id_Pubisher == obj.Publishers_Id);
            }
            List<BookDto> list = new List<BookDto>();
            foreach (var obj in books)
            {
                list.Add(new BookDto
                { IdPubisher = obj.Publishers_Id, Location = obj.Publishers.Location, Id = obj.Book_Id, Name = obj.Publishers.Name, Title = obj.title });
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
                { IdPubisher = obj.Publishers_Id, Location = obj.Publishers.Location, Id = obj.Book_Id, Name = obj.Publishers.Name, Title = obj.title });
            }

            return Ok(list);
        }
        [HttpGet("getBookeMultiLevelExplicitLoading")]
        public IActionResult getBookeMultiLevelExplicitLoading()
        {
            var books = _context.Books.ToList();
            List<BookDto> list = new List<BookDto>();
            foreach (var obj in books)
            {
                _context.Entry(obj).Reference(u => u.Publishers).Load();
                _context.Entry(obj).Collection(u => u.BookAuthors).Load();
                foreach(var bookAuth in obj.BookAuthors)
                {
                    _context.Entry(bookAuth).Reference(u => u.Authors).Load();
                    list.Add(new BookDto
                    {
                        IdPubisher = obj.Publishers_Id,
                        Location = obj.Publishers.Location,
                        Id = obj.Book_Id,
                        Name = obj.Publishers.Name,
                        Title = obj.title,
                        DOB = bookAuth.Authors.DOB,
                        NameOFAutor = bookAuth.Authors.Name

                    }); 
                }
            }
           
         

            return Ok(list);
        }
   
        [HttpGet("getBookeEagerLoading")]
        public IActionResult getBookeEagerLoading()
        {
            List<Book> books = _context.Books.Include(x => x.Publishers).ToList();
            List<BookDto> list = new List<BookDto>();
            foreach (var obj in books)
            {
                foreach(var bookAut in obj.BookAuthors)
                list.Add(new BookDto
                { IdPubisher = obj.Publishers_Id, Location = obj.Publishers.Location, Id = obj.Book_Id,
                    Name = obj.Publishers.Name, Title = obj.title,DOB= bookAut.Authors.DOB,NameOFAutor=bookAut.Authors.Name });
            }

            return Ok(list);
        }
        [HttpGet("getBookeMultiLevelEagerLoading")]
        public IActionResult getBookeMultiLevelEagerLoading()
        {
            List<Book> books = _context.Books.Include(x => x.Publishers).Where(x=>x.BookAuthors.Count!=0).Include(x => x.BookAuthors).ThenInclude(x => x.Authors).ToList();
  
            List<BookDto> list = new List<BookDto>();
            foreach (var obj in books)
            {
                foreach (var bookAut in obj.BookAuthors)
                    list.Add(new BookDto
                    {
                        IdPubisher = obj.Publishers_Id,
                        Location = obj.Publishers.Location,
                        Id = obj.Book_Id,
                        Name = obj.Publishers.Name,
                        Title = obj.title,
                        DOB = bookAut.Authors.DOB,
                        NameOFAutor = bookAut.Authors.Name
                    });
            }

            return Ok(list);
        }
        [HttpGet("getExcutionFirstSenario")]
        public IActionResult getExcutionFirstSenario()
        {
            //First Senario
            var bookColliction = _context.Books;
            int? TotalNumberOfchapters = 0;
            foreach (var book in bookColliction)
            {

                TotalNumberOfchapters += book?.NumberOfchapters??0;
            }
            return Ok(TotalNumberOfchapters);
        }
        [HttpGet("getExcutionSecondSenario")]
        public IActionResult getExcutionSecondSenario()
        {
            //Second Senario
            var bookList = _context.Books.ToList();
            int? TotalNumberOfchapters = 0;
            foreach (var book in bookList)
            {

                TotalNumberOfchapters += book?.NumberOfchapters ?? 0;
            }
            return Ok(TotalNumberOfchapters);
        }
        [HttpGet("getExcutionThirdSenario")]
        public IActionResult getExcutionThirdSenario()
        {
            //Thired Senario
            int BookCount = _context.Books.Count();
            return Ok(BookCount);
        }
        [HttpGet("getIEnumerable")]
        public IActionResult getIEnumerable()
        {
            IEnumerable<Book> bookList = _context.Books;
            List<BookDto> list = new List<BookDto>();
            var FilterBook = bookList.Where(b => b.NumberOfchapters > 7).ToList();
            foreach (var obj in FilterBook)
            {
                list.Add(new BookDto
                { Id = obj.Book_Id, Title = obj.title,NumberOfchapters=obj?.NumberOfchapters });
            }
            return Ok(list);

        }

        [HttpGet("getIQueryable")]
        public IActionResult getIQueryable()
        {
            IQueryable<Book> bookList = _context.Books;
            List<BookDto> list = new List<BookDto>();
            var FilterBook = bookList.Where(b => b.NumberOfchapters > 7).ToList();
            foreach (var obj in FilterBook)
            {
                list.Add(new BookDto
                { Id = obj.Book_Id, Title = obj.title, NumberOfchapters = obj?.NumberOfchapters });
            }
            return Ok(list);
        }

        [HttpPost("addBook")]
        public IActionResult addBook(BookDetail BookDetail)
        {
            _context.Add(BookDetail);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost("updateBook")]
        public IActionResult updateBook(int BookDetailId)
        {
            var updatedBook = _context.BookDetails.FirstOrDefault(x => x.Id == BookDetailId);
            updatedBook.NumberOfPage = 300;
            _context.Update(updatedBook);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("CompareUpdateVSAttachBookDetail")]
        public IActionResult CompareUpdateVSAttachBookDetail(int BookDetailId)
        {
            var updatedBook = _context.Books.Include(b => b.bookDetail).FirstOrDefault(b => b.Book_Id == 5);
            updatedBook.bookDetail.NumberOfPage = 700;
            /*Update it will change the state of all enitities(related enitities + the target enitity)  as modified
              becasue of that BookDetail entity will be update AND Book enity IN DB */
            _context.Update(updatedBook);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("CompareAttachVSUpdateBookDetail")]
        public IActionResult CompareAttachVSUpdateBookDetail(int BookDetailId)
        {
            var updatedBook = _context.Books.Include(b => b.bookDetail).FirstOrDefault(b => b.Book_Id == 5);
            updatedBook.bookDetail.NumberOfPage = 600;
            /*Attach it will put the state of all enitities as UnChange state and just mark the target entity as modified 
              becasue of that ONLY BookDetail entity will be update IN DB */
            _context.Attach(updatedBook);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("ManualUpdate")]
        public IActionResult ManualUpdate(int BookDetailId)
        {
            // it will fire the Updtate statment even without modifying any thing 
            var updatedBook = _context.Books.Include(b => b.bookDetail).FirstOrDefault(b => b.Book_Id == 5);
            _context.Entry(updatedBook).State=EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult deleteBook(int BookDetailId)
        {
            var selectedBook = _context.BookDetails.FirstOrDefault(x => x.Id == BookDetailId);
            _context.Remove(selectedBook);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("GetDataFromView")]
        public IActionResult GetDataFromView()
        {
            var viewBook = _context.BookDetailsFromViews.ToList();
            return Ok(viewBook);
        }
        [HttpGet("GetUsingSqlRow")]
        public IActionResult GetUsingSqlRow()
        {
            var Books = _context.Books.FromSqlRaw($"select * from dbo.books where Book_Id={1}").ToList();//EF it will send clear ID
            var booksInterpolated = _context.Books.FromSqlInterpolated($"select * from dbo.books where Book_Id={1}").ToList(); //EF it will decrypt ID
             
            var bookSproc = _context.Books.FromSqlInterpolated($"EXEC dbo.getAllBookDetails{12}");
            return Ok(Books);
        }
        [HttpGet("IncludeFillter")]
        public IActionResult IncludeFillter()
        {
            List<BookDto> list = new List<BookDto>();
            var Books = _context.Books.Include(b => b.BookAuthors.Where(ba => ba.Author_Id == 5).OrderByDescending(ba => ba.Book_Id).Take(2)).ToList();
            foreach (var obj in Books)
            {
                list.Add(new BookDto
                { Id = obj.Book_Id, Title = obj.title, NumberOfchapters = obj?.NumberOfchapters });
            }
            return Ok(list);

        }
    }
}
