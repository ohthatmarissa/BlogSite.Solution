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
    public ActionResult Search(string search)
    {

      List<Post> searchResult = Post.PostSearch(search);
      return View(searchResult);
    }


    [HttpGet("/blogs/{blogId}/posts/new")]
      public ActionResult New(int blogId)
      {
        return View(blogId);
      }


    //   [HttpPost("/blogs/{id}/posts")]
    //   public ActionResult Create(string title, string content, DateTime postDate, int id)
    //   {
    //     Post myPost = new Post(title, content, postDate, id);
    //     myPost.SetDate(postDate);
    //     myPost.Save();
    //     return RedirectToAction("Show", "Blogs", id);
    //   }


    // [HttpPost("/blogs/{blogId}/posts/{postId}")]
    // public ActionResult Show(int blogId, int postId,  DateTime postDate)
    // {
    //   Post myPost = Post.Find(postId);
      
    //   return View(myPost);
    // }

    
  }
}