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
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                _publisherService.AddPublisher(publisher);
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
        public IActionResult GetAllPublishers()
        {
            var allPublishers = _publisherService.GetAllPublishers();
            return Ok(allPublishers);
        }

        [HttpGet("{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var publisherById = _publisherService.GetPublisherById(id);
            return Ok(publisherById);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePublisherById(int id,[FromBody] PublisherVM publisher)
        {
            _publisherService.UpdatePublisherById(id,publisher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publisherService.DeleteById(id);
            return NoContent();
        }
    }
}
