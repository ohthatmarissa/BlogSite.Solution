using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BlogSite.Models
{
  public class Post
  {
    private int _id;
    private int _blogId;
    private string _title;
    private string _content;
    private DateTime _date;
    

    public Post(string postTitle, string postContent, DateTime postDate, int postBlogId, int id = 0)
    {
      _title = postTitle;
      _content = postContent;
      _date = postDate;
      _blogId = postBlogId;
      _id = id;
    }

    public string GetTitle()
    {
      return _title;
    }

    public string GetContent()
    {
      return _content;
    }

    public DateTime GetDate()
    {
      return _date;
    }


    public int GetblogId()
    {
      return _blogId;
    }

    public int GetId()
    {
      return _id;
    }

    public override int GetHashCode()
    {
    return this.GetId().GetHashCode();
    }

  }
}