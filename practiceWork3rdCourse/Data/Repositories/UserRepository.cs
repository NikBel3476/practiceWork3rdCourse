using Microsoft.EntityFrameworkCore;
using practiceWork3rdCourse.Models;

namespace practiceWork3rdCourse.Data.Repositories;

public class UserRepository: IRepository<User>
{
    private readonly ApplicationDbContext _context;
    
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User? Get(string id)
    {
        return _context.Users.Find(id);
    }

    public void Create(User user)
    {
        var existingUser = _context.Users.Find(user.Id);
        if (existingUser == null)
        {
            _context.Users.AddAsync(user);
        }
    }

    public void Update(User user)
    {
        var existingUser = _context.Users.Find(user.Id);
        if (existingUser != null)
        {
            _context.Entry(user).State = EntityState.Modified;   
        }
    }

    public void Delete(string id)
    {
        var user = _context.Users.Find(id);
        if (user != null)
        {
            _context.Users.Remove(user);   
        }
    }
}