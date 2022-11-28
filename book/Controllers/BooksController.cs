using book.Data;
using book.Data.Services;
using book.Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private AppDbContext _context;

        public BookService _bookService;
        private readonly ILogger<BooksController> logger;

        public BooksController(BookService bookService, ILogger<BooksController> logger,AppDbContext context)
        {
            _bookService = bookService;
            this.logger = logger;
            _context= context;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            try
            {
                _bookService.AddBook(book);
                this.logger.LogInformation("Book has been created");
                return Ok();
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex.Message+" .This error happened");
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetAllBooks(string? sortBy,string? searchString)
        {
            var allBooks=_bookService.GetAllBooks(sortBy,searchString);
            return Ok(allBooks);
        }



        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookVM book)
        {
            var updateBook=_bookService.UpdateBookById(id, book);
            return Ok(updateBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _bookService.DeleteById(id);
            return NoContent();
        }
    }
}
