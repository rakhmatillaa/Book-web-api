using book.Data.Services;
using book.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        public AuthorService _authorService;
        public AuthorsController(AuthorService authorService, ILogger<AuthorsController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] AuthorVM author)
        {
            try
            {
                await _authorService.AddAuthorAsync(author);
                this._logger.LogInformation("Author has been created");
                return Ok();
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.Message + " .This error happened");
                return BadRequest();
            }
        }
        


        [HttpGet("GetAuthorsWithBooks/{id}")]
        public async Task<IActionResult> GetAuthorWithBooks(int id)
        {
            var auhtorsWithBooks= await _authorService.GetAuthorWithBooksAsync(id);
            return Ok(auhtorsWithBooks);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors(string? sortBy,string? searchString)
        {
            var allAuthors=await _authorService.GetAllAuthorsAsync(sortBy,searchString);
            return Ok(allAuthors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthorById(int id, [FromBody] AuthorVM author)
        {
            await _authorService.UpdateAuthorByIdAsync(id, author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _authorService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
