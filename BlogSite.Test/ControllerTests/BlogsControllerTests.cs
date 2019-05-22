using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogSite.Controllers;
using BlogSite.Models;

namespace BlogSite.Tests
{
    [TestClass]
    public class BlogsControllerTests : IDisposable
  {
    public void Dispose()
    {
      Blog.ClearAll();
      Post.ClearAll();
      Community.ClearAll();
    }
    public BlogsControllerTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=blog_site_test;";
    }


      [TestMethod]
      public void Show_ReturnsCorrectView_True()
      {
        BlogsController controller = new BlogsController();
        ActionResult showBlogView = controller.Show(1);
        Assert.IsInstanceOfType(showBlogView, typeof(ViewResult));
      }


      [TestMethod]
      public void New_ReturnsCorrectView_True()
      {
        BlogsController controller = new BlogsController();
        ActionResult newBlogView = controller.New();
        Assert.IsInstanceOfType(newBlogView, typeof(ViewResult));
      }


      [TestMethod]
      public void Login_ReturnsCorrectView_True()
      {
        BlogsController controller = new BlogsController();
        ActionResult loginView = controller.Login();
        Assert.IsInstanceOfType(loginView, typeof(ViewResult));
      }
      
      
      


    }
}