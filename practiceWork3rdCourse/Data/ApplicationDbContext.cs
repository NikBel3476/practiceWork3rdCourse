using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using practiceWork3rdCourse.Models;

namespace practiceWork3rdCourse.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    
    // ...
    public DbSet<Post> Posts => Set<Post>();
    // ...
}