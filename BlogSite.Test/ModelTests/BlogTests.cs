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
      Post.ClearAll();
      Community.ClearAll();
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
   [TestMethod]
   public void Delete_DeletesSpecificBlog_True()
   {
     Blog newBlog = new Blog("", "");
     newBlog.Save();
     Blog newBlog2 = new Blog("", "");
     newBlog2.Save();
     newBlog.Delete();
     List<Blog> result = Blog.GetAll();
     Assert.AreEqual(newBlog2, result[0]);
   }
   [TestMethod]
   public void Edit_ChangesBlogElements_Strings()
   {
     Blog newBlog = new Blog("", "");
     newBlog.Save();
     string password = "password";
     string about = "about";
     newBlog.Edit("", password, "", about);
     newBlog.Save();
     Assert.AreEqual(password, newBlog.GetPassword());
     Assert.AreEqual(about, newBlog.GetAbout());
   }
   [TestMethod]
   public void Authenticate_ChecksIfPasswordAndUsernameAreTheSame_True()
   {
     Blog newBlog = new Blog("a", "b");
     newBlog.Save();
     Assert.AreEqual(true, Blog.Authenticate("a", "b"));
   }
   [TestMethod]
   public void Login_AddsUserToSessionBlogTable_User()
   {
     Blog newBlog = new Blog("a", "b", 2);
     newBlog.Save();
     Blog.Login("a", "b");
     Assert.AreEqual(newBlog.GetId(), SessionBlog.GetId());
   }
   [TestMethod]
   public void GetPosts_GetsAllBlogPosts_PostList()
   {
     Blog newBlog = new Blog("a", "b");
     newBlog.Save();
     Post newPost = new Post("", "", 5);
     newPost.Save();
     Post newPost2 = new Post("", "", newBlog.GetId());
     newPost2.Save();
     List <Post> result = newBlog.GetPosts();
     List <Post> postList = new List <Post>{newPost2};
     CollectionAssert.AreEqual(result, postList);
   }

   [TestMethod]
   public void GetCommunities_ReturnsBlogCommunities_CommunityList()
   {
     Community newCommunity = new Community("","");
     newCommunity.Save();
     Blog newBlog = new Blog("","");
     newBlog.Save();
     newBlog.AddCommunity(newCommunity.GetId());
     List <Community> result = newBlog.GetCommunities();
     List <Community> communityList = new List <Community>{newCommunity};
     Console.WriteLine(result.Count);
     Console.WriteLine(communityList.Count);
     CollectionAssert.AreEqual(result, communityList);
   }

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
