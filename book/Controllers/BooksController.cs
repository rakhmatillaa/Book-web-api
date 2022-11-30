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
        public async Task<IActionResult> AddBook([FromBody] BookVM book)
        {
            try
            {
                await _bookService.AddBookAsync(book);
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
        public async Task<IActionResult> GetAllBooks(string? sortBy,string? searchString)
        {
            var allBooks=await _bookService.GetAllBooksAsync(sortBy,searchString);
            return Ok(allBooks);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book =await _bookService.GetBookByIdAsync(id);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookVM book)
        {
            var updateBook=await _bookService.UpdateBookByIdAsync(id, book);
            return Ok(updateBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            await _bookService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
