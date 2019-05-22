using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogSite.Controllers;
using BlogSite.Models;

namespace BlogSite.Tests
{
    [TestClass]
    public class CommunitiesControllerTests : IDisposable
  {
    public void Dispose()
    {
      Blog.ClearAll();
      Post.ClearAll();
      Community.ClearAll();
    }
    public CommunitiesControllerTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=blog_site_test;";
    }


      [TestMethod]
      public void Show_ReturnsCorrectView_True()
      {
        CommunitiesController controller = new CommunitiesController();
        ActionResult showCommunityView = controller.Show(1);
        Assert.IsInstanceOfType(showCommunityView, typeof(ViewResult));
      }


      [TestMethod]
      public void Index_ReturnsCorrectView_True()
      {
        CommunitiesController controller = new CommunitiesController();
        ActionResult indexBlogView = controller.Index();
        Assert.IsInstanceOfType(indexBlogView, typeof(ViewResult));
      }


      [TestMethod]
    public void Create_ReturnsCorrectActionType_RedirectToActionResult()
    {
        CommunitiesController controller = new CommunitiesController();
        IActionResult view = controller.Create("name", "description");
        Assert.IsInstanceOfType(view, typeof(RedirectToActionResult));
    }

    [TestMethod]
    public void Create_RedirectsToCorrectAction_Index()
    {
        CommunitiesController controller = new CommunitiesController();
        RedirectToActionResult actionResult = controller.Create("name", "description") as RedirectToActionResult;
        string result = actionResult.ActionName;
        Assert.AreEqual(result, "Index");
    }

    }
}