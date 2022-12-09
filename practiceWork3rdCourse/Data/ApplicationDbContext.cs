using Microsoft.AspNetCore.Identity;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        var roles = new List<IdentityRole>()
        {
            new IdentityRole()
            {
                Id = Enums.Roles.User.ToString(),
                Name = Enums.Roles.User.ToString(),
                NormalizedName = Enums.Roles.User.ToString().ToUpper()
            },
            new IdentityRole()
            {
                Id = Enums.Roles.Admin.ToString(),
                Name = Enums.Roles.Admin.ToString(),
                NormalizedName = Enums.Roles.Admin.ToString().ToUpper()
            }
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);
        
        var users = new List<User>()
        {
            new User
            {
                Id = "ee3477c1-ded5-4362-8342-6d932e2b5a78",
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                // Password@123
                PasswordHash = "AQAAAAIAAYagAAAAEN0ACH7Otu6T0Wr18M3YLjHUfM6kskCB57bUVj43gOYK6bGyoXvQxgttwBq43J1Sng==",
                NormalizedUserName="USER",
                NormalizedEmail= "USER@GMAIL.COM",
                SecurityStamp = "DMSXK5UGNJK2CUJU764GFRUS3TRTULXQ",
                ConcurrencyStamp = "fb10e7b8-9594-442e-a7a5-ee636782fbb0",
            },
            new User
            {
                Id = "534533ac-e2fc-467d-bd0a-941faed3e29a",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FirstName = "Amit",
                LastName = "Naik",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                // Password@123
                PasswordHash = "AQAAAAIAAYagAAAAEEMERfwFHwjUKWd3OE2k9Yv92fuBYUueDSEDIo+FT73MnRLMHtlRS2P8QAx0m4189Q==",
                NormalizedEmail= "ADMIN@GMAIL.COM",
                NormalizedUserName="ADMIN"
            },
        };
        
        modelBuilder.Entity<User>().HasData(users);
        
        var userRoles = new List<IdentityUserRole<string>>()
        {
            new IdentityUserRole<string>
            {
                RoleId = Enums.Roles.User.ToString(),
                UserId = "ee3477c1-ded5-4362-8342-6d932e2b5a78"
            },
            new IdentityUserRole<string>
            {
                RoleId = Enums.Roles.Admin.ToString(),
                UserId = "534533ac-e2fc-467d-bd0a-941faed3e29a"
            },
        };
        
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    }
}