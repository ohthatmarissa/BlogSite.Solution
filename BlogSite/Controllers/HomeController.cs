using System;
using Microsoft.AspNetCore.Mvc;
using BlogSite.Models;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        if(SessionBlog.GetId() == 0)
        {
          return View();
        }
        else
        {
          return RedirectToAction("Show", "Blogs", new{id = SessionBlog.GetId()});
        }
      }

    }
}
