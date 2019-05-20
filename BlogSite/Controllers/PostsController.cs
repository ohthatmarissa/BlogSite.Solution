using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using BlogSite.Models;
using System.Linq;
using MySql.Data.MySqlClient;

namespace BlogSite.Controllers
{
  public class PostsController : Controller
  {

      [HttpGet("/posts")]
      public ActionResult Index()
      {
          List<Post> allPosts = Post.GetAll();
          return View(allPosts);
      }
  }
}