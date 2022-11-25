using book.Data.BookVM;
using book.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        public BookService _bookService;
        private readonly ILogger<BooksController> logger;

        public BooksController(BookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            this.logger = logger;
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
        public IActionResult GetAllBooks()
        {
            var allBooks=_bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("{title}")]
        public IActionResult GetBookByStringWithAuthor(string title)
        {
            var book=_bookService.GetBookByStringWithAuthor(title);
            return Ok(book);
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
