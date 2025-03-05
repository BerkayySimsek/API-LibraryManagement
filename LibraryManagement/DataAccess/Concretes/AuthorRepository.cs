using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.Models;

namespace LibraryManagement.DataAccess.Concretes
{
    public class AuthorRepository : IAuthorRepository
    {
        BaseDbContext context = new BaseDbContext();

        public void Add(Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
        }

        public void Delete(Author author)
        {
            context.Authors.Remove(author);
            context.SaveChanges();
        }

        public List<Author> GetAll()
        {
            return context.Authors.ToList();
        }

        public Author? GetById(int id)
        {
            return context.Authors.Find(id);
        }

        public void Update(Author author)
        {
            context.Authors.Update(author);
            context.SaveChanges();
        }
    }
}
