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
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            try
            {
                _authorService.AddAuthor(author);
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
        public IActionResult GetAuthorWithBooks(int id)
        {
            var auhtorsWithBooks= _authorService.GetAuthorWithBooks(id);
            return Ok(auhtorsWithBooks);
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var allAuthors=_authorService.GetAllAuthors();
            return Ok(allAuthors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            return Ok(author);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthorById(int id, [FromBody] AuthorVM author)
        {
            _authorService.UpdateAuthorById(id, author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _authorService.DeleteById(id);
            return NoContent();
        }
    }
}
