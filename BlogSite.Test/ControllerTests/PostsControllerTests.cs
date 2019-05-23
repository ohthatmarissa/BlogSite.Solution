using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogSite.Controllers;
using BlogSite.Models;

namespace BlogSite.Tests
{
    [TestClass]
    public class PostsControllerTests : IDisposable
  {
    public void Dispose()
    {
      Blog.ClearAll();
      Post.ClearAll();
      Community.ClearAll();
    }
    public PostsControllerTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=blog_site_test;";
    }


      [TestMethod]
      public void Show_ReturnsCorrectView_True()
      {
        PostsController controller = new PostsController();
        ActionResult showPostView = controller.Show(1, 1);
        Assert.IsInstanceOfType(showPostView, typeof(ViewResult));
      }


      [TestMethod]
      public void New_ReturnsCorrectView_True()
      {
        PostsController controller = new PostsController();
        ActionResult newPostView = controller.New(1);
        Assert.IsInstanceOfType(newPostView, typeof(ViewResult));
      }

      [TestMethod]
      public void Edit_ReturnsCorrectView_True()
      {
        PostsController controller = new PostsController();
        ActionResult newPostView = controller.Edit(1,1);
        Assert.IsInstanceOfType(newPostView, typeof(ViewResult));
      }



      [TestMethod]
      public void Search_ReturnsCorrectView_True()
      {
        PostsController controller = new PostsController();
        ActionResult searchView = controller.Search("search word");
        Assert.IsInstanceOfType(searchView, typeof(ViewResult));
      }
      

    [TestMethod]
    public void Delete_ReturnsCorrectActionType_RedirectToActionResult()
    {
        PostsController controller = new PostsController();
        IActionResult view = controller.Destroy(1,1);
        Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Delete_RedirectsToCorrectAction_ShowBlogs()
    {
        PostsController controller = new PostsController();
        RedirectToActionResult actionResult = controller.Destroy(1,1) as RedirectToActionResult;
        string result = actionResult.ActionName;
        Assert.AreEqual(result, "Show", "Blogs");
    }
      
    
    }
}