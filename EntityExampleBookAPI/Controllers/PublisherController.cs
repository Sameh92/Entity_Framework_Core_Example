using Book_Model;
using BookDataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EntityExampleBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PublisherController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet("getPublisher")]
        public IActionResult getPublisher()
        {
            var publisher = _context.Publisher.ToList();
            return Ok();
        }
        [HttpPost("addPublisher")]
        public IActionResult addPublisher(Publisher book)
        {
            _context.Publisher.Add(book);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost("updatePublisher")]
        public IActionResult updatePublisher(int PublisherID)
        {
            var updatedPublisher = _context.Publisher.FirstOrDefault(x => x.Id_Pubisher == PublisherID);
            updatedPublisher.Name = "title";
            _context.Update(updatedPublisher);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("deletePublisher")]
        public IActionResult deletePublisher(int PublisherID)
        {
            var selectedPublisher = _context.Publisher.FirstOrDefault(x => x.Id_Pubisher == PublisherID);
            _context.Remove(selectedPublisher);
            _context.SaveChanges();
            return Ok();
        }
    }
}
