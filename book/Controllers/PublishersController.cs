﻿using book.Data.Services;
using book.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublisherService _publisherService;

        public PublishersController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publisherService.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllPublishers()
        {
            var allPublishers = _publisherService.GetAllPublishers();
            return Ok(allPublishers);
        }

        [HttpGet("{id}")]
        public IActionResult GetPublisherById(int ID)
        {
            var publisherById = _publisherService.GetPublisherById(ID);
            return Ok(publisherById);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePublisherById(int id,[FromBody] PublisherVM publisher)
        {
            var updatePublisher = _publisherService.UpdatePublisherById(id,publisher);
            return Ok(updatePublisher);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publisherService.DeleteById(id);
            return NoContent();
        }
    }
}
