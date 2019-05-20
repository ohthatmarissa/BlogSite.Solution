using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogSite.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace BlogSite.Tests
{
  [TestClass]
  public class BlogTest
  {
    public BlogTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=blog_site_test;";
    }
    [TestMethod]
    public void BlogConstructor_CreatesNewBlog_Blog()
    {
      Blog newBlog = new Blog("", "");
      Assert.AreEqual(typeof(Blog), newBlog.GetType());
    }
    [TestMethod]
    public void GetUserName_GetsNameOfBlogUser_String()
    {
      string username = "username";
      Blog newBlog = new Blog(username, "");
      Assert.AreEqual(username, newBlog.GetUsername());
    }
   [TestMethod]
   public void GetPassword()
   {
     string password = "password";
     Blog newBlog = new Blog ("", password);
     Assert.AreEqual(password, newBlog.GetPassword());
   }
   [TestMethod]
   public void GetTitle()
   {
     string title = "title";
     Blog newBlog = new Blog ("", "");
     newBlog.SetTitle(title);
     Assert.AreEqual(title, newBlog.GetTitle());
   }
   [TestMethod]
   public void GetId()
   {
     Blog newBlog = new Blog ("", "");
     Assert.AreEqual(0, newBlog.GetId());
   }
   [TestMethod]
   public void GetAbout()
   {
     string about = "about";
     Blog newBlog = new Blog ("", "");
     newBlog.SetAbout(about);
     Assert.AreEqual(about, newBlog.GetAbout());
   }





 }
}
