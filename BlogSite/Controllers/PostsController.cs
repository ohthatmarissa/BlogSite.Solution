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

    [HttpGet("/posts/search")]
    public ActionResult Search()
    {
      List<Post> list = new List <Post> {};
       return View(list);
    }

    [HttpPost("/posts/search")]
    public ActionResult Search(string searchWord)
    {
      List<Post> searchResult = Post.PostSearch(searchWord);
      return View(searchResult);
    }


  }
}