using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BlogSite.Models
{
  public class Blog
  {
    private int _id;
    private string _title;
    private string _about;
    private string _username;
    private string _password;

    public Blog(string username, string password, int id = 0)
    {
      _username = username;
      _password = password;
      _title = "My Awesome Blog";
      _about = "";
      _id = id;
    }

    public string GetUsername()
    {
      return _username;
    }

    public string GetPassword()
    {
      return _password;
    }

    public string GetTitle()
    {
      return _title;
    }

    public void SetTitle(string title)
    {
      _title = title;
    }


    public int GetId()
    {
      return _id;
    }


    public string GetAbout()
    {
      return _about;
    }

    public void SetAbout(string about)
    {
      _about = about;
    }

    public static List<string> GetAllUsernames()
    {
        List<string> allUsernames = new List<string>{};
        foreach(Blog blog in GetAll())
        {
            allUsernames.Add(blog.GetUsername());
        }
        return allUsernames;
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
                bool aboutEquality = this.GetAbout() == newBlog.GetAbout();
                bool usernameEquality = this.GetUsername() == newBlog.GetUsername();
                bool passwordEquality = this.GetPassword() == newBlog.GetPassword();
                return (idEquality && titleEquality && aboutEquality && usernameEquality && passwordEquality);
            }
        }

     public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO blogs (title, about, username, password) VALUES (@thisTitle, @thisAbout, @thisUsername, @thisPassword);";

        MySqlParameter title = new MySqlParameter("@thisTitle", _title);
        MySqlParameter about = new MySqlParameter("@thisAbout", _about);
        MySqlParameter username = new MySqlParameter("@thisUsername", _username);
        MySqlParameter password = new MySqlParameter("@thisPassword", _password);
        cmd.Parameters.Add(title);
        cmd.Parameters.Add(about);
        cmd.Parameters.Add(username);
        cmd.Parameters.Add(password);

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
        int blogId = rdr.GetInt32(0);
        string blogTitle = rdr.GetString(1);
        string blogAbout = rdr.GetString(2);
        string blogUsername = rdr.GetString(3);
        string blogPassword = rdr.GetString(4);
        Blog newBlog = new Blog(blogUsername, blogPassword, blogId);
        newBlog.SetTitle(blogTitle);
        newBlog.SetAbout(blogAbout);
        allBlogs.Add(newBlog);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allBlogs;
    }


    public static Blog FindById(int id)
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
      int blogId = 0;
      string blogTitle = "";
      string blogAbout = "";
      string blogUsername = "";
      string blogPassword = "";
      while(rdr.Read())
      {
        blogId = rdr.GetInt32(0);
        blogTitle = rdr.GetString(1);
        blogAbout = rdr.GetString(2);
        blogUsername = rdr.GetString(3);
        blogPassword = rdr.GetString(4);
      }
      Blog newBlog = new Blog(blogUsername, blogPassword, blogId);
      newBlog.SetTitle(blogTitle);
      newBlog.SetAbout(blogAbout);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newBlog;
    }

    public static Blog FindByUsername(string username)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM blogs WHERE username = @searchUsername;";
      MySqlParameter searchUsername = new MySqlParameter("@searchUsername", username);
      cmd.Parameters.Add(searchUsername);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int blogId = 0;
      string blogTitle = "";
      string blogAbout = "";
      string blogUsername = "not found";
      string blogPassword = "";
      while(rdr.Read())
      {
        blogId = rdr.GetInt32(0);
        blogTitle = rdr.GetString(1);
        blogAbout = rdr.GetString(2);
        blogUsername = rdr.GetString(3);
        blogPassword = rdr.GetString(4);
      }
      Blog newBlog = new Blog(blogUsername, blogPassword, blogId);
      newBlog.SetTitle(blogTitle);
      newBlog.SetAbout(blogAbout);
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
        MySqlCommand cmd = new MySqlCommand( "DELETE FROM blogs WHERE id = @BlogId; DELETE FROM blogs_communities WHERE blog_id = @BlogId;", conn);
        MySqlParameter blogIdParameter = new MySqlParameter("@BlogId", _id);
        cmd.Parameters.Add(blogIdParameter);
        cmd.ExecuteNonQuery();
        if (conn != null)
        {
            conn.Close();
        }
    }



    public void Edit(string newUsername, string newPassword, string newTitle, string newAbout)
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"UPDATE blogs SET username = @newUsername, password = @newPassword, title = @newTitle, about = @newAbout WHERE id = @searchId;";
        MySqlParameter username = new MySqlParameter("@newUsername", newUsername);
        MySqlParameter password = new MySqlParameter("@newPassword", newPassword);
        MySqlParameter title = new MySqlParameter("@newTitle", newTitle);
        MySqlParameter about = new MySqlParameter("@newAbout", newAbout);
        MySqlParameter searchId = new MySqlParameter("@searchId", _id);
        cmd.Parameters.Add(username);
        cmd.Parameters.Add(password);
        cmd.Parameters.Add(title);
        cmd.Parameters.Add(about);
        cmd.Parameters.Add(searchId);
        cmd.ExecuteNonQuery();
        _username = newUsername;
        _password = newPassword;
        _title = newTitle;
        _about = newAbout;
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }

      public static bool Authenticate(string username, string password)
      {
        Blog match = Blog.FindByUsername(username);
        if(match.GetPassword() == password)
        {
          return true;
        }
        else
        {
          return false;
        }
      }

      public static void Login(string username, string password)
      {
        SessionBlog.Logout();
        if(Authenticate(username, password))
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO session_blogs (blog_id) VALUES (@thisBlogId);";
          MySqlParameter thisBlogId = new MySqlParameter("@thisBlogId", Blog.FindByUsername(username).GetId());
          cmd.Parameters.Add(thisBlogId);
          cmd.ExecuteNonQuery();
          conn.Close();
          if(conn != null)
          {
            conn.Dispose();
          }
        }
      }

      public List<Post> GetPosts()
      {
        List<Post> allPosts = new List<Post>{};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM posts WHERE blog_id = @thisId;";
        MySqlParameter thisId = new MySqlParameter("@thisId", _id);
        cmd.Parameters.Add(thisId);
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int postId = rdr.GetInt32(0);
          int blogId = rdr.GetInt32(1);
          string postTitle = rdr.GetString(2);
          string postContent = rdr.GetString(3);
          DateTime postDate = rdr.GetDateTime(4);
          string postFile =  rdr.IsDBNull(5) ? null : rdr.GetString(5);

          Post thisPost = new Post(postTitle, postContent, postFile, blogId, postId);
          thisPost.SetDate(postDate);
          allPosts.Add(thisPost);
        }
        conn.Close();
        if(conn != null)
        {
          conn.Dispose();
        }
        return allPosts;
      }

      public List<Community> GetCommunities()
      {
        List<Community> allCommunities = new List<Community>{};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
<<<<<<< HEAD
        cmd.CommandText = @"SELECT communities.* FROM communities JOIN blogs_communities ON (communities.id = blogs_communities.blog_id) WHERE blog_id = @thisId;";
=======
        cmd.CommandText = @"SELECT communities.* FROM communities JOIN blogs_communities ON (communities.id = blogs_communities.community_id) WHERE blog_id = @thisId;";
>>>>>>> master
        MySqlParameter thisId = new MySqlParameter("@thisId", _id);
        cmd.Parameters.Add(thisId);
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int communityId = rdr.GetInt32(0);
          string communityName = rdr.GetString(1);
          string communityDescription = rdr.GetString(2);
          Community thisCommunity = new Community(communityName, communityDescription, communityId);
          allCommunities.Add(thisCommunity);
        }
        conn.Close();
        if(conn != null)
        {
          conn.Dispose();
        }
        return allCommunities;
      }

      public void AddCommunity(int communityId)
      {
        if(communityId != 0)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO blogs_communities (blog_id, community_id) VALUES (@thisBlogId, @thisCommunityId);";
          MySqlParameter thisBlogId = new MySqlParameter("@thisBlogId", _id);
          MySqlParameter thisCommunityId = new MySqlParameter("@thisCommunityId", communityId);
          cmd.Parameters.Add(thisBlogId);
          cmd.Parameters.Add(thisCommunityId);
          cmd.ExecuteNonQuery();
          conn.Close();
          if(conn != null)
          {
            conn.Dispose();
          }
        }
      }

      public void RemoveCommunity(int communityId)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM blogs_communities WHERE blog_id = @thisBlogId AND community_id = @thisCommunityId;";
        MySqlParameter thisBlogId = new MySqlParameter("@thisBlogId", _id);
        MySqlParameter thisCommunityId = new MySqlParameter("@thisCommunityId", communityId);
        cmd.Parameters.Add(thisBlogId);
        cmd.Parameters.Add(thisCommunityId);
        cmd.ExecuteNonQuery();
        conn.Close();
        if(conn != null)
        {
          conn.Dispose();
        }
      }

      public bool IsLoggedIn()
      {
        return _id == SessionBlog.GetId();
      }
  }
}
