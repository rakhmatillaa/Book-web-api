using book.Data.Services;
using book.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublisherService _publisherService;
        private readonly ILogger<PublishersController> _logger;

        public PublishersController(PublisherService publisherService, ILogger<PublishersController> logger)
        {
            _publisherService = publisherService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                await _publisherService.AddPublisherAsync(publisher);
                _logger.LogInformation("Publisher has been added successfully");
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message + " .This error happened");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPublishers(string? orderBy,string? searchString)
        {
            var allPublishers =await _publisherService.GetAllPublishersAsync(orderBy,searchString);
            return Ok(allPublishers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            var publisherById =await _publisherService.GetPublisherByIdAsync(id);
            return Ok(publisherById);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisherById(int id,[FromBody] PublisherVM publisher)
        {
            await _publisherService.UpdatePublisherByIdAsync(id,publisher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisherById(int id)
        {
            await _publisherService.DeleteByIdAsync(id);
            return NoContent();
        }
    }
}
