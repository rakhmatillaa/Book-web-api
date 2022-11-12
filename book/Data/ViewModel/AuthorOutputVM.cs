using book.Data.Models;

namespace book.Data.ViewModel
{
    public class AuthorOutputVM
    { 
        public int Id { get; set; }
        public string FullName { get; set; }

        // Navigation property:

        public List<Book> Books { get; set; }
    }
}
