using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogSite.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace BlogSite.Tests
{
  [TestClass]
  public class PostTest
  {
    public PostTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=blog_site_test;";
    }
    [TestMethod]
    public void PostConstructor_CreatesNewPost_Post()
    {
      Post newPost = new Post("", "", 0);
      Assert.AreEqual(typeof(Post), newPost.GetType());
    }
  }

}
