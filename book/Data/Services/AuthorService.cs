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

        public Author GetAuthorById(int authorId)
        {
            var authorById = _context.Authors.FirstOrDefault(o => o.Id == authorId);
            return authorById;
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
