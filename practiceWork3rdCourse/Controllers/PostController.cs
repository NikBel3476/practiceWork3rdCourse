using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using practiceWork3rdCourse.Data;
using practiceWork3rdCourse.Models;

namespace practiceWork3rdCourse.Controllers;

[Authorize]
public class PostController : Controller
{
    // ...
    private readonly UnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public PostController(
        // ...
        ApplicationDbContext context,
        UserManager<User> userManager
    )
    {
        // ...
        _unitOfWork = new UnitOfWork(context);
        _userManager = userManager;
    }

public IActionResult Index()
{
    var posts =  _unitOfWork.Posts.GetAll();
    // ...

    ViewData.Model = posts;
    return View();
}
    
    // GET: Post/Create
    public ActionResult Create()
    {
        // ...
        return View();
    }
    
    // POST: Post/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Post post)
    {
        try
        {
            var userId = this._userManager.GetUserId(HttpContext.User);
            var user = _unitOfWork.Users.Get(userId);
            if (!this.IsValid(post, user))
            {
                return BadRequest();
            }
            // ...

            post.Id = Guid.NewGuid().ToString();
            post.Author = user;
            post.DateOfCreation = DateTime.Now;
            
            _unitOfWork.Posts.Create(post);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
    
    // GET: Post/Edit/5
    public ActionResult Edit(int id)
    {
        // ...
        return View();
    }
    
    // POST: User/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(string id, Post updatedPost)
    {
        try
        {
            var userId = this._userManager.GetUserId(HttpContext.User);
            var user = _unitOfWork.Users.Get(userId);
            var originPost = _unitOfWork.Posts.Get(id);
            
            if (originPost == null || !this.IsValid(updatedPost, user))
            {
                return BadRequest();
            }
            // ...

            updatedPost.Id = originPost.Id;
            updatedPost.Author = originPost.Author;
            if (!_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                updatedPost.DateToUnpin = originPost.DateToUnpin;
            }

            _unitOfWork.Posts.Update(updatedPost);
            _unitOfWork.Save();
            
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    private bool IsValid(Post post, User user)
    {
        var userIsAdmin = _userManager.IsInRoleAsync(user, "Admin").Result;
        if (
            string.IsNullOrEmpty(post.Title)
            || string.IsNullOrEmpty(post.Content)
            || (post.DateToUnpin != null && !userIsAdmin)
            || post.DateToUnpin < DateTime.Now
        )
        {
            return false;
        }
        // ...

        return true;
    }
}