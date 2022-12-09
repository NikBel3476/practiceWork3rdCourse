using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using practiceWork3rdCourse.Models;

namespace practiceWork3rdCourse.Data.Repositories;

public class PostRepository: IRepository<Post>
{
    private readonly ApplicationDbContext _context;

    public PostRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Post> GetAll()
    {
        var rawPostsDbSet = _context.Posts;
        // ...
                
        var postsWithDateToUnpin = rawPostsDbSet
            .Where(post =>
                post.DateToUnpin != null && post.DateToUnpin >= DateTime.Now)
            .OrderByDescending(p => p.DateOfCreation)
            .Include(p => p.Author)
            .ToList();
        
        var postsWithoutDateToUnpin = rawPostsDbSet
            .Where(post =>
                post.DateToUnpin == null || post.DateToUnpin < DateTime.Now)
            .OrderByDescending(p => p.DateOfCreation)
            .Include(p => p.Author)
            .ToList();
        
        var posts = postsWithDateToUnpin.Concat(postsWithoutDateToUnpin);
        return posts;
    }

    public Post? Get(string id)
    {
        return _context.Posts
            .Where(p => p.Id == id)
            .Include(p => p.Author)
            .FirstOrDefault();
    }

    public void Create(Post post)
    {
        _context.Posts.Add(post);
    }

    public void Update(Post post)
    {
        var existingPost = _context.Posts.Find(post.Id);
        if (existingPost != null)
        {
            _context.Entry(post).State = EntityState.Modified;   
        }
    }

    public void Delete(string id)
    {
        var post = _context.Posts.Find(id);
        if (post != null)
        {
            _context.Posts.Remove(post);   
        }
    }
}