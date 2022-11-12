using book.Data.Models;
using book.Data.ViewModel;
using System.Security.Cryptography.X509Certificates;

namespace book.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int Id)
        {
            var author = _context.Authors.Where(n => n.Id == Id).Select(n => new AuthorWithBooksVM()
            {
                FullName=n.FullName,
                BookTitles=n.Book_Authors.Select(n=>n.Book.Title).ToList()
            }).FirstOrDefault();
            return author;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName,
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public List<Author> GetAllAuthors()
        {
            var authors = _context.Authors.ToList();
            return authors;
        }

        public AuthorOutputVM GetAuthorById(int authorId)
        {
            var  _author= _context.Authors.FirstOrDefault(o => o.Id == authorId);
            return new AuthorOutputVM
            {
                Id = _author.Id,
                FullName = _author.FullName
            };
        }

        public void UpdateAuthorById(int authorId,AuthorVM author)
        {
            var newAuthorById=_context.Authors.FirstOrDefault(o => o.Id == authorId);
        
            if(newAuthorById != null)
            {
                newAuthorById.FullName = author.FullName;

                _context.SaveChanges();
            }
            
        }

        public void DeleteById(int authorId)
        {
            var _author=_context.Authors.FirstOrDefault(o => o.Id == authorId);

            if(_author != null)
            {
                _context.Authors.Remove(_author);
                _context.SaveChanges();
            }
        }

    }
}
