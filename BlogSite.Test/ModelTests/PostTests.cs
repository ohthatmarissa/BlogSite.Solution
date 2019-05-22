using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlogSite.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace BlogSite.Tests
{
  [TestClass]
  public class PostTest : IDisposable
  {
    public void Dispose()
    {
      Post.ClearAll();
    }

    public PostTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=blog_site_test;";
    }
    [TestMethod]
    public void PostConstructor_CreatesNewPost_Post()
    {
      Post newPost = new Post("", "", "", 0);
      Assert.AreEqual(typeof(Post), newPost.GetType());
    }
    [TestMethod]
    public void GetTitle_GetsPostTitle_String()
    {
      string title = "title";
      Post newPost = new Post(title, "", "", 0);
      Assert.AreEqual(title, newPost.GetTitle());
    }
    [TestMethod]
    public void GetContent_GetsPostContent_String()
    {
      string content = "content";
      Post newPost = new Post("", content, "", 0);
      Assert.AreEqual(content, newPost.GetContent());
    }
    [TestMethod]
    public void GetBlogId_GetsIdOfPostBlog_Int()
    {
      int blogId = 2;
      Post newPost = new Post("", "", "", blogId);
      Assert.AreEqual(blogId, newPost.GetBlogId());
    }
    [TestMethod]
    public void GetId_GetsIdOfPost_Int()
    {
      Post newPost = new Post("", "", "", 0);
      Assert.AreEqual(0, newPost.GetId());
    }
    //Set title
    //Set Content
    //Set blogId

    [TestMethod]
    public void GetAll_ReturnsEmptyPostList_PostList()
    {
      List<Post> allPosts = new List <Post>{};
      List <Post> result = Post.GetAll();
      CollectionAssert.AreEqual(allPosts, result);
    }

    [TestMethod]
    public void Save_SavesPostToDataBase_PostList()
    {
      Post newPost = new Post("", "", "", 0);
      newPost.Save();
      List <Post> result = Post.GetAll();
      List<Post> testList = new List <Post>{newPost};
      Console.WriteLine(result[0].GetDate()+"hi");
      Console.WriteLine(testList[0].GetDate()+"hi2");
      CollectionAssert.AreEqual(result, testList);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfPostsAreSame_True()
    {
      Post newPost = new Post("", "", "", 0);
      Post newPost2 = new Post("", "", "", 0);
      Console.WriteLine(newPost.GetDate());
      Console.WriteLine(newPost2.GetDate());

      Assert.AreEqual(newPost, newPost2);
    }
    [TestMethod]
    public void Find_ReturnsCorrectPostFromDatabase_Post()
    {
      Post newPost = new Post("", "", "", 0);
      newPost.Save();
      Post foundPost = Post.Find(newPost.GetId());
      Assert.AreEqual(newPost, foundPost);
    }
    public void Delete_DeletesSpecificPost_True()
    {
      Post newPost = new Post("", "", "", 0);
      newPost.Save();
      Post newPost2 = new Post("", "", "", 0);
      newPost2.Save();
      newPost.Delete();
      List<Post> result = Post.GetAll();
      Assert.AreEqual(newPost2, result[0]);
    }

    [TestMethod]
    public void Edit_EditsPostElements_Strings()
    {
      Post newPost = new Post("", "", "", 0);
      newPost.Save();
      string title = "title";
      string content = "content";
      string file = "file";
      newPost.Edit(title, content, file);
      Assert.AreEqual(title, newPost.GetTitle());
      Assert.AreEqual(content, newPost.GetContent());
    }
    [TestMethod]
    public void PostSearch_SearchesForContentContainingSearchWord_Content()
    {
      Post newPost = new Post("", "", "", 0);
      newPost.Save();
      Post newPost2 = new Post("", "a", "", 1);
      newPost2.Save();
      List<Post> newList = new List <Post>{newPost2};
      List <Post> result = Post.PostSearch("a");
      Console.WriteLine(result.Count);
      Console.WriteLine(newList.Count);
      CollectionAssert.AreEqual(result, newList);
    }

   }

}
