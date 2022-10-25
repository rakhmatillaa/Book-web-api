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
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var allBooks=_bookService.GetAllBooks();
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
