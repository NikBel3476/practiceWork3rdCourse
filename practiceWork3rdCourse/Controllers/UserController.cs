using Microsoft.AspNetCore.Mvc;
using practiceWork3rdCourse.Data;
using practiceWork3rdCourse.Models;

namespace practiceWork3rdCourse.Controllers;
public class UserController : Controller
{
    private readonly ILogger<PostController> _logger;
    private readonly UnitOfWork _unitOfWork;

    public UserController(ILogger<PostController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _unitOfWork = new UnitOfWork(context);
    }
    
    // GET: User
    public ActionResult Index()
    {
        var users = _unitOfWork.Users.GetAll();
        ViewData.Model = users;
        return View();
    }

    // GET: User/Details/5
    // public ActionResult Details(int id)
    // {
    //     return View();
    // }
    //
    // GET: User/Create
    // public ActionResult Create()
    // {
    //     return View();
    // }
    //
    // // POST: User/Create
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public ActionResult Create(User user)
    // {
    //     try
    //     {
    //         _unitOfWork.Users.Create(user);
    //         _unitOfWork.Save();
    //
    //         return RedirectToAction(nameof(Index));
    //     }
    //     catch
    //     {
    //         return View();
    //     }
    // }
    
    // // GET: User/Edit/5
    // public ActionResult Edit(int id)
    // {
    //     return View();
    // }
    //
    // // POST: User/Edit/5
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public ActionResult Edit(int id, IFormCollection collection)
    // {
    //     try
    //     {
    //         // TODO: Add update logic here
    //
    //         return RedirectToAction(nameof(Index));
    //     }
    //     catch
    //     {
    //         return View();
    //     }
    // }
    //
    // // GET: User/Delete/5
    // public ActionResult Delete(int id)
    // {
    //     return View();
    // }
    //
    // // POST: User/Delete/5
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public ActionResult Delete(int id, IFormCollection collection)
    // {
    //     try
    //     {
    //         // TODO: Add delete logic here
    //
    //         return RedirectToAction(nameof(Index));
    //     }
    //     catch
    //     {
    //         return View();
    //     }
    // }
}