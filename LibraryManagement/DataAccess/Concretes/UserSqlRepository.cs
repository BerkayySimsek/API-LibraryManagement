using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Contexts;
using LibraryManagement.Models;

namespace LibraryManagement.DataAccess.Concretes;

public class UserSqlRepository : IUserRepository
{
    private BaseDbContext _context;
    public UserSqlRepository(BaseDbContext context)
    {
        _context = context;
    }
    public void Add(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User GetByEmail(string email)
    {
        User user = _context.Users.SingleOrDefault(x => x.Email == email);
        return user;
    }

    public User GetById(Guid id)
    {
        return _context.Users.Find(id);
    }
}
