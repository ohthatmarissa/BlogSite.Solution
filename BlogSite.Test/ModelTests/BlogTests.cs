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
      string username =
      Blog newBlog = new Blog(username, "");
      Assert.AreEqual(username, newBlog.GetUserName());
    }
   [TestMethod]
   public void GetPassword()
   {

   }
   [TestMethod]
   public void GetTitle()
   {

   }
   [TestMethod]
   public void SetTitle()
   {

   }
   [TestMethod]
   public void GetId()
   {

   }
   [TestMethod]
   public void GetAbout()
   {

   }
   [TestMethod]
   public void SetAbout()
   {

   }




 }
}
