using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogSite.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace BlogSite.Tests
{
  [TestClass]
  public class BlogTest : IDisposable
  {
    public void Dispose()
    {
      Blog.ClearAll();
    }
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

   [TestMethod]
   public void GetAll_ReturnsEmptyBlogList_BlogList()
   {
     List<Blog> allBlogs = new List <Blog>{};
     List <Blog> result = Blog.GetAll();
     CollectionAssert.AreEqual(allBlogs, result);
   }
   [TestMethod]
   public void Save_SavesBlogToDatabase_BlogList()
   {
     Blog newBlog = new Blog("", "");
     newBlog.Save();
     List <Blog> result = Blog.GetAll();
     List<Blog> testList = new List <Blog>{newBlog};
     CollectionAssert.AreEqual(result, testList);
   }
   [TestMethod]
   public void FindById_FindsBlogFromDatabase_Blog()
   {
     Blog newBlog = new Blog("", "");
     newBlog.Save();
     Blog foundBlog = Blog.FindById(newBlog.GetId());
     Assert.AreEqual(newBlog, foundBlog);
   }
   [TestMethod]
   public void FindByUsername_FindBlogFromDatabaseBlog()
   {
     Blog newBlog = new Blog("", "");
     newBlog.Save();
     Blog foundBlog = Blog.FindByUsername(newBlog.GetUsername());
     Assert.AreEqual(newBlog, foundBlog);
   }
   // [TestMethod]
   // public void Delete()
   // {
   //
   // }
   // [TestMethod]
   // public void Edit()
   // {
   //
   // }
   //
   // [TestMethod]
   // public void Authenticate()
   // {
   //
   // }
   // public void Login()
   // {
   //
   // }
   // [TestMethod]
   // public void GetCommunities()
   // {
   //
   // }
   //
   // [TestMethod]
   // public void AddCommunity()
   // {
   //
   // }
   //
   // [TestMethod]
   // public void RemoveCommunity()
   // {
   //
   // }

 }
}
