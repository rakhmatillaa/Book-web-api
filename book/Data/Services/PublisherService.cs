using book.Data.Models;
using book.Data.ViewModel;

namespace book.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
               Name = publisher.Name,
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public List<Publisher> GetAllPublishers(string? sortBy,string? searchString)
        {
            var publishers = _context.Publishers.OrderBy(n=>n.Name).ToList();

            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "desc":
                        publishers=publishers.OrderByDescending(n=>n.Name).ToList(); 
                        break;
                    default:
                        break;
                }
            }
            
            if(!String.IsNullOrEmpty(searchString))
            {
                publishers=publishers.Where(n=>n.Name.Contains(searchString)).ToList();
            }

            return publishers;
        }

        public Publisher GetPublisherById(int publisherId)
        {
            var publisherById = _context.Publishers.FirstOrDefault(n=>n.Id==publisherId);
            return publisherById;
        }

        public void UpdatePublisherById(int publisherId, PublisherVM publisher)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);

            if (_publisher != null)
            {
                _publisher.Name = publisher.Name;

                _context.SaveChanges(); //saves this stuff in the database
            }
        }

        public void DeleteById(int publisherId)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == publisherId);

            if (publisherId != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
