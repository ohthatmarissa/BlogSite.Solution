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
      Community newCommunity = new Community("", "");
      Assert.AreEqual(typeof(Community), newCommunity.GetType());
    }

    [TestMethod]
    public void GetName_GetsCommunityName_String()
    {
      string name = "name";
      Community newCommunity = new Community(name, "");
      Assert.AreEqual(name, newCommunity.GetName());

    }
    [TestMethod]
    public void GetDescription_GetsCommunityDescription_String()
    {
      string description = "description";
      Community newCommunity = new Community("", description);
      Assert.AreEqual(description, newCommunity.GetDescription());
    }
    [TestMethod]
    public void GetId_GetsCommunityId_Int()
    {
      Community newCommunity = new Community("", "", 2);
      Assert.AreEqual(2, newCommunity.GetId());
    }
    [TestMethod]
    public void GetAll_ReturnsEmptyCommunityList_CommunityList()
    {
      List<Community> allCommunities = new List <Community>{};
      List <Community> result = Community.GetAll();
      CollectionAssert.AreEqual(allCommunities, result);
    }
    [TestMethod]
    public void Save_SavesCommunityToDatabase_DatabaseList()
    {
      Community newCommunity = new Community("", "");
      newCommunity.Save();
      List <Community> result = Community.GetAll();
      List<Community> testList = new List <Community>{newCommunity};
      CollectionAssert.AreEqual(result, testList);
    }
    [TestMethod]
    public void Find_ReturnsCorrectCommunityFromDatabase_Community()
    {
      Community newCommunity = new Community("", "");
      newCommunity.Save();
      Community foundCommunity = Community.Find(newCommunity.GetId());
      Assert.AreEqual(newCommunity, foundCommunity);
    }
    [TestMethod]
    public void Delete_DeletesSpecificCommunity_True()
    {
      Community newCommunity = new Community("", "");
      newCommunity.Save();
      Community newCommunity2 = new Community("", "");
      newCommunity2.Save();
      newCommunity.Delete();
      List<Community> result = Community.GetAll();
      Assert.AreEqual(newCommunity2, result[0]);
    }
    [TestMethod]
    public void Edit()
    {
      Community newCommunity = new Community("", "");
      newCommunity.Save();
      string name = "name";
      string description = "description";
      newCommunity.Edit(name, description);
      Assert.AreEqual(name, newCommunity.GetName());
      Assert.AreEqual(description, newCommunity.GetDescription());
    }
    // [TestMethod]
    // public void GetBlogs()
    // {
    //
    // }
    // [TestMethod]
    // public void AddBlog()
    // {
    //
    // }
  }
}
