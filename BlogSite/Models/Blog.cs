using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BlogSite.Models
{
  public class Blog
  {
    private int _id;
    private string _title;
    private string _description;
    

    public Blog(string blogTitle, string blogDescription, int id = 0) 
    {
      _title = blogTitle;
      _description = blogDescription;
      _id = id;
    }

    public string GetTitle()
    {
      return _title;
    }


    public int GetId()
    {
      return _id;
    }


    public string GetDescription()
    {
      return _description;
    }


    public override int GetHashCode()
    {
    return this.GetId().GetHashCode();
    }


    public override bool Equals(System.Object otherBlog)
        {
        if (!(otherBlog is Blog))
            {
                return false;
            }
        else
            {
                Blog newBlog = (Blog) otherBlog;
                bool idEquality = this.GetId() == newBlog.GetId();
                bool titleEquality = this.GetTitle() == newBlog.GetTitle();
                bool descriptionEquality = this.GetDescription() == newBlog.GetDescription();
                return (idEquality && titleEquality && descriptionEquality);
            }
        }

    public void Dispose()
    {
      Blog.ClearAll();
      Post.ClearAll();
      Community.ClearAll();
    }


     public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO blogs (title, description) VALUES (@title, @description);";

        MySqlParameter title = new MySqlParameter();
        title.ParameterName = "@title";
        title.Value = this._title;
        cmd.Parameters.Add(title);

        MySqlParameter description = new MySqlParameter();
        description.ParameterName = "@description";
        description.Value = this._description;
        cmd.Parameters.Add(description);

        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
            {
                conn.Dispose();
            }
    }


    public static List<Blog> GetAll()
    {
      List<Blog> allBlogs = new List<Blog> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM blogs;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int BlogId = rdr.GetInt32(0);
        string BlogTitle = rdr.GetString(1);
        string BlogDescription = rdr.GetString(2);
        Blog newBlog = new Blog(BlogTitle, BlogDescription, BlogId);
        allBlogs.Add(newBlog);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allBlogs;
    }


    public static Blog Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM blogs WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int BlogId = 0;
      string BlogTitle = "";
      string BlogDescription = "";
      while(rdr.Read())
      {
        BlogId = rdr.GetInt32(0);
        BlogTitle = rdr.GetString(1);
        BlogDescription = rdr.GetString(2);
      }
      Blog newBlog = new Blog(BlogTitle, BlogDescription, BlogId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newBlog;
    }


    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM blogs;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    public void Delete()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = new MySqlCommand( "DELETE FROM blogs WHERE id = @BlogId;", conn);
        MySqlParameter blogIdParameter = new MySqlParameter();
        blogIdParameter.ParameterName = "@BlogId";
        blogIdParameter.Value = this.GetId();
        cmd.Parameters.Add(blogIdParameter);
        cmd.ExecuteNonQuery();

        if (conn != null)
        {
            conn.Close();
        }
    }



    public void Edit(string newTitle, string newDescription)
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"UPDATE blogs SET title = @newTitle, description = @newDescription WHERE id = (@searchId);";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = _id;
        cmd.Parameters.Add(searchId);

        MySqlParameter title = new MySqlParameter();
        title.ParameterName = "@newTitle";
        title.Value = newTitle;
        cmd.Parameters.Add(title);

        MySqlParameter description = new MySqlParameter();
        description.ParameterName = "@newDescription";
        description.Value = newDescription;
        cmd.Parameters.Add(description);

        _title = newTitle;
        _description = newDescription;
        conn.Close();
        if (conn != null)
            {
                conn.Dispose();
            }
        }



  }
}