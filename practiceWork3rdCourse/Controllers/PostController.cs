﻿using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using practiceWork3rdCourse.Data;
using practiceWork3rdCourse.Models;

namespace practiceWork3rdCourse.Controllers;

[Authorize]
public class PostController : Controller
{
    private readonly ILogger<PostController> _logger;
    private readonly UnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public PostController(
        ILogger<PostController> logger,
        ApplicationDbContext context,
        UserManager<User> userManager
    )
    {
        _logger = logger;
        _unitOfWork = new UnitOfWork(context);
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var posts =  _unitOfWork.Posts.GetAll();
        ViewData.Model = posts;
        return View();
    }
    
    // GET: Post/Create
    public ActionResult Create()
    {
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
        return View();
    }
    
    // POST: User/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            // TODO: Add update logic here
    
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
    
    public bool IsValid(Post post, User user)
    {
        if (
            string.IsNullOrEmpty(post.Title)
            || string.IsNullOrEmpty(post.Content)
            || (post.DateToUnpin != null && User.IsInRole("Admin"))
            || post.DateToUnpin < DateTime.Now.AddDays(1)
        )
        {
            return false;
        }
        // ...

        return true;
    }
}