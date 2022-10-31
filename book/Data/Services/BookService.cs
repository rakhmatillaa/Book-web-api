using book.Data.Models;
using System.Threading;
//this class works as a connection link between controller and API
namespace book.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context=context;
        }

        public void AddBook(BookVM.BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                isRead=book.isRead,
                Rate= 1,
                DateRead=book.DateRead,
                Genre=book.Genre,
                CoverUrl=book.CoverUrl,
                PublisherId=book.PublisherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks() =>_context.Books.ToList();

        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId);

        public Book UpdateBookById(int bookId,BookVM.BookVM book)
        {
            var _book=_context.Books.FirstOrDefault(n => n.Id == bookId);

            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.isRead = book.isRead;
                _book.Rate = 1;
                _book.DateRead = book.DateRead;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges(); //saves this stuff in the database
            }
            
            return _book;
        }

        public void DeleteById(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);

            if (bookId != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
