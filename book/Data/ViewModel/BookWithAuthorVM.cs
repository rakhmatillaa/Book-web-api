using book.Data.Models;

namespace book.Data.ViewModel
{
    public class BookWithAuthorVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isRead { get; set; }
        public int Rate { get; set; }
        public DateTime DateRead { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public string PublisherName { get; set; }
        public List<string> AuthorsNames { get; set; }
    }
}
