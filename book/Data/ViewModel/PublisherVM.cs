using book.Data.Models;

namespace book.Data.ViewModel
{
    public class PublisherVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
