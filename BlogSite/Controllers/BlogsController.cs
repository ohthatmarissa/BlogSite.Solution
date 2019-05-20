using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using BlogSite.Models;
using System.Linq;
using MySql.Data.MySqlClient;

namespace BlogSite.Controllers
{
  public class BlogsController : Controller
  {

      [HttpGet("/blogs")]
      public ActionResult Index()
      {
          List<Blog> allBlogs = Blog.GetAll();
          return View(allBlogs);
      }
  }
}