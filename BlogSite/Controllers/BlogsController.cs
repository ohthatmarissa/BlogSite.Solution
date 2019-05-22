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

      [HttpGet("/blogs/register")]
      public ActionResult New()
      {
        ViewBag.Title = "Get Your Set Up On!";
        return View();
      }

      [HttpPost("/blogs/register")]
      public ActionResult Create(string username, string password1, string password2)
      {
        if(password1 == password2)
        {
          Blog newBlog = new Blog(username, password1);
          newBlog.Save();
          Blog.Login(username, password1);
          
          return View("Edit", newBlog);
        }
        else
        {
          return RedirectToAction("New");
        }
      }

      [HttpGet("/blogs/login")]
      public ActionResult Login()
      {
        ViewBag.Title = "Log In";
        return View();
      }

      [HttpPost("/blogs/login")]
      public ActionResult Update(string username, string password)
      {
        Blog thisBlog = Blog.FindByUsername(username);
        Blog.Login(username, password);
        return RedirectToAction("Show", new{id = thisBlog.GetId()});
      }

      [HttpPost("/blogs/logout")]
      public ActionResult Logout()
      {
        SessionBlog.Logout();
        return RedirectToAction("Index", "Home");
      }

      [HttpGet("/blogs/{id}/edit")]
      public ActionResult Edit(int id)
      {
        Blog foundBlog = Blog.FindById(id);
        ViewBag.Title = "Edit Blog Details";
        return View(foundBlog);
      }

      [HttpPost("/blogs/{blogId}/update")]
      public ActionResult Update(int blogId, string title, string about)
      {
        Blog editBlog = Blog.FindById(blogId);
        editBlog.Edit(editBlog.GetUsername(), editBlog.GetPassword(), title, about);
        return RedirectToAction("Show", new{id = blogId});
      }

      [HttpGet("/blogs/{id}")]
      public ActionResult Show(int id)
      {
        Blog thisBlog = Blog.FindById(id);
        ViewBag.Title = thisBlog.GetTitle();
        return View(thisBlog);
      }

      [HttpPost("/blogs/{id}/communities/new")]
      public ActionResult Update(int id, int selectedCommunity)
      {
        Blog thisBlog = Blog.FindById(id);
        thisBlog.AddCommunity(selectedCommunity);
        return RedirectToAction("Show", new{id=id});
      }

      [HttpPost("/blogs/{blogId}/remove/{communityId}")]
      public ActionResult Delete(int blogId, int communityId)
      {
        Blog thisBlog = Blog.FindById(blogId);
        thisBlog.RemoveCommunity(communityId);
        return RedirectToAction("Show", new{id = blogId});
      }
  }
}
