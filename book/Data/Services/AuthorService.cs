using book.Data.Models;
using book.Data.ViewModel;

namespace book.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AuthorWithBooksVM> GetAuthorWithBooksAsync(int Id)
        {
            var author = _context.Authors.Where(n => n.Id == Id).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();
            return author;
        }

        public async Task AddAuthorAsync(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName,
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public async Task<List<Author>> GetAllAuthorsAsync(string? sortBy, string? searchString)
        {
            var authors = _context.Authors.OrderBy(a => a.FullName).ToList();

            if (!String.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "desc":
                        authors = authors.OrderByDescending(a => a.FullName).ToList();
                        break;
                    default:
                        break;
                }
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                authors = authors.Where(a => a.FullName.Contains(searchString,StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return authors;
        }

        public async Task<AuthorOutputVM> GetAuthorByIdAsync(int authorId)
        {
            var _author = _context.Authors.FirstOrDefault(o => o.Id == authorId);
            
            return new AuthorOutputVM
            {
                Id = _author.Id,
                FullName = _author.FullName
            };

        }

        public async Task UpdateAuthorByIdAsync(int authorId, AuthorVM author)
        {
            var newAuthorById = _context.Authors.FirstOrDefault(o => o.Id == authorId);

            if (newAuthorById != null)
            {
                newAuthorById.FullName = author.FullName;

                _context.SaveChanges();
            }

        }

        public async Task DeleteByIdAsync(int authorId)
        {
            var _author = _context.Authors.FirstOrDefault(o => o.Id == authorId);

            if (_author != null)
            {
                _context.Authors.Remove(_author);
                _context.SaveChanges();
            }
        }

    }
}
