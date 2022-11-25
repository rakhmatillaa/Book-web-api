using book.Data.Models;
using book.Data.ViewModel;
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

            foreach(var id in book.AuthorsId)
            {
                var _bookAuthor = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_bookAuthor);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks() =>_context.Books.OrderBy(b=>b.Title).ToList();

        public BookWithAuthorVM GetBookByStringWithAuthor(string title)
        {
            var _bookByString=_context.Books.Where(b=>b.Title == title).Select(book => new BookWithAuthorVM()
            {
                Title = book.Title,
                Description = book.Description,
                isRead = book.isRead,
                Rate = 1,
                DateRead = book.DateRead,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorsNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();

            return _bookByString;
        }

        public BookWithAuthorVM GetBookById(int bookId)
        {
            var _bookWithAuthor = _context.Books.Where(n => n.Id == bookId).Select(book => new BookWithAuthorVM()
            {
                Title = book.Title,
                Description = book.Description,
                isRead = book.isRead,
                Rate = 1,
                DateRead = book.DateRead,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName=book.Publisher.Name,
                AuthorsNames=book.Book_Authors.Select(n=>n.Author.FullName).ToList()
            }).FirstOrDefault();

            return _bookWithAuthor;
        }

        //many-to-many relationship on EntityFrameworkCore6

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
