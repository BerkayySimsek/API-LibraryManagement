using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Contexts;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DataAccess.Concretes;


// Single Responsibilitiy
// Open Closed
// Liskov Substitution Principle
// Interface Segregation Principle
public class BookRepository : IBookRepository
{

    private BaseDbContext _context;
    public BookRepository(BaseDbContext context)
    {
        _context = context;
    }

    public void Add(Book book)
    {
        _context.Entry(book).State = EntityState.Added;
        _context.SaveChanges();
    }

    public void Delete(Book book)
    {
        _context.Books.Remove(book);
        _context.SaveChanges();
    }

    public List<Book> GetAll()
    {
        List<Book> books = _context.Books.Include(x => x.Category).Include(z => z.Author).ToList();
        return books;
    }

    public List<Book> GetAllByPriceRange(double min, double max)
    {
        List<Book> books = _context.Books.Where(x => x.Price <= max && x.Price >= min).ToList();
        return books;
    }

    public Book? GetById(int id)
    {
        Book? book = _context.Books.Include(x => x.Category).Include(z => z.Author).SingleOrDefault(X => X.Id == id);
        return book;
    }

    public Book? GetByIsbn(string isbn)
    {
        Book? book = _context.Books.FirstOrDefault(x => x.Isbn == isbn);
        return book;
    }

    public void Update(Book book)
    {
        _context.Books.Update(book);
        _context.SaveChanges();
    }
}
