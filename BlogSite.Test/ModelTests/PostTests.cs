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
    [TestMethod]
    public void GetTitle_GetsPostTitle_String()
    {
      string title = "title";
      Post newPost = new Post(title, "", 0);
      Assert.AreEqual(title, newPost.GetTitle());
    }
    [TestMethod]
    public void GetContent_GetsPostContent_String()
    {
      string content = "content";
      Post newPost = new Post("", content, 0);
      Assert.AreEqual(content, newPost.GetContent());
    }
    [TestMethod]
    public void GetBlogId_GetsIdOfPostBlog_Int()
    {
      int blogId = 2;
      Post newPost = new Post("", "", blogId);
      Assert.AreEqual(blogId, newPost.GetBlogId());
    }
    [TestMethod]
    public void GetId_GetsIdOfPost_Int()
    {
      Post newPost = new Post("", "", 0);
      Assert.AreEqual(0, newPost.GetId());
    }
  }

}
