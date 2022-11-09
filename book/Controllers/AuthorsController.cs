using book.Data.Services;
using book.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public AuthorService _authorService;
        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorService.AddAuthor(author);
            return Ok();
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
