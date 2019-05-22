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
        ViewBag.Title = "Compose your masterpiece";
        return View(blogId);
      }


      [HttpPost("/blogs/{id}/posts/new")]
      public ActionResult Create(string title, string content, int id)
      {
        Post myPost = new Post(title, content, id);
        myPost.Save();
        return RedirectToAction("Show", new{blogId = myPost.GetBlogId(), postId = myPost.GetId()});
      }


    [HttpGet("/blogs/{blogId}/posts/{postId}")]
    public ActionResult Show(int blogId, int postId)
    {
      Post myPost = Post.Find(postId);
      ViewBag.Title = Blog.FindById(blogId).GetTitle();
      return View(myPost);
    }

    [HttpGet("/blogs/{blogId}/posts/{postId}/edit")]
    public ActionResult Edit(int blogId, int postId)
    {
      Post editPost = Post.Find(postId);
      ViewBag.Title = "Change Things Up";
      return View(editPost);
    }

    [HttpPost("/blogs/{blogId}/posts/{postId}/update")]
    public ActionResult Update(int blogId, int postId, string title, string content)
    {
      Post editPost = Post.Find(postId);
      editPost.Edit(title, content);
      return RedirectToAction("Show", new{blogId = blogId, postId = postId});
    }
  }
}