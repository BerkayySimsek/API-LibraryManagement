using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Contexts;
using LibraryManagement.Models;

namespace LibraryManagement.DataAccess.Concretes
{
    public class AuthorRepository : IAuthorRepository
    {
        private BaseDbContext _context;
        public AuthorRepository(BaseDbContext context)
        {
            _context = context;
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Delete(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author? GetById(int id)
        {
            return _context.Authors.Find(id);
        }

        public void Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }
}
