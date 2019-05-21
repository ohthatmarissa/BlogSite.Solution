using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogSite.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace BlogSite.Tests
{
  [TestClass]
  public class CommunityTest : IDisposable
  {
    public void Dispose()
    {
      Blog.ClearAll();
      Post.ClearAll();
      Community.ClearAll();
    }
    public CommunityTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=blog_site_test;";
    }
    [TestMethod]
    public void CommunityConstructor_CreatesNewCommunity_Community()
    {
      Community newCommunity = new Community("", "", 0);
      Assert.AreEqual(typeof(Community), newCommunity.GetType());
     }
    [TestMethod]
    public void GetDescription()
    {

    }
    [TestMethod]
    public void GetId()
    {

    }
    [TestMethod]
    public void Save()
    {

    }
    [TestMethod]
    public void GetAll()
    {

    }
    [TestMethod]
    public void Find()
    {

    }
    [TestMethod]
    public void Delete()
    {

    }
    [TestMethod]
    public void Edit()
    {

    }
    [TestMethod]
    public void GetBlogs()
    {

    }
    [TestMethod]
    public void AddBlog()
    {

    }
  }
}
