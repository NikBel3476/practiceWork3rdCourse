using practiceWork3rdCourse.Data.Repositories;

namespace practiceWork3rdCourse.Data;

public class UnitOfWork : IDisposable
{
    private bool _disposed = false;
    private readonly ApplicationDbContext _context;
    private UserRepository? _userRepository;
    private PostRepository? _postRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public UserRepository Users
    {
        get
        {
            if (this._userRepository == null)
            {
                this._userRepository = new UserRepository(_context);
            }

            return this._userRepository;
        }
    }
    
    public PostRepository Posts
    {
        get
        {
            if (this._postRepository == null)
            {
                this._postRepository = new PostRepository(_context);
            }

            return this._postRepository;
        }
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }
    
    public virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            this._disposed = true;
        }
    }
 
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}