using book.Data.Models;

namespace book.Data.ViewModel
{
    public class PublisherVM
    {
        public string Name { get; set; }
        // Navigation property
        public List<Book> Books { get; set; }
    }
}
