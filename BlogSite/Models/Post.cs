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
    

    public Post(string postTitle, string postContent, int postBlogId, int id = 0)
    {
      _title = postTitle;
      _content = postContent;
      _date = DateTime.Now;
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

    public void  SetDate(DateTime postDate)
    {
       _date = postDate;
    }


    public int GetBlogId()
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


    public override bool Equals(System.Object otherPost)
        {
        if (!(otherPost is Post))
            {
                return false;
            }
        else
            {
                Post newPost = (Post) otherPost;
                bool idEquality = this.GetId() == newPost.GetId();
                bool titleEquality = this.GetTitle() == newPost.GetTitle();
                bool contentEquality = this.GetContent() == newPost.GetContent();
                bool dateEquality = this.GetDate() == newPost.GetDate();
                bool blogIdEquality = this.GetBlogId() == newPost.GetBlogId();
                return (idEquality && titleEquality && contentEquality && dateEquality&& blogIdEquality);
            }
        }

    
    public void Dispose()
    {
      Blog.ClearAll();
      Post.ClearAll();
      Community.ClearAll();
    }


    public static void ClearAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM posts;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }


    public void Save()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO posts (title, content, date, blog_id) VALUES (@title, @content, @date, @blogId);";

        MySqlParameter title = new MySqlParameter();
        title.ParameterName = "@title";
        title.Value = this._title;
        cmd.Parameters.Add(title);

        MySqlParameter content = new MySqlParameter();
        content.ParameterName = "@content";
        content.Value = this._content;
        cmd.Parameters.Add(content);

        MySqlParameter date = new MySqlParameter();
        date.ParameterName = "@date";
        date.Value = this._date;
        cmd.Parameters.Add(date);

        MySqlParameter blogId = new MySqlParameter();
        blogId.ParameterName = "@blogId";
        blogId.Value = this._blogId;
        cmd.Parameters.Add(blogId);
        
        cmd.ExecuteNonQuery();
        _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
            {
                conn.Dispose();
            }

    }


    public static List<Post> GetAll()

    {
    List<Post> allPosts = new List<Post> { };
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT id, blog_id, title, content, date FROM posts;";
    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    while(rdr.Read())
    {
        int postId = rdr.GetInt32(0);
        int postBlogId = rdr.GetInt32(1);
        string postTitle = rdr.GetString(2);
        string postContent = rdr.GetString(3);
        DateTime postDate = rdr.GetDateTime(4);
        
        Post newPost = new Post(postTitle, postContent, postBlogId, postId);
        newPost.SetDate(postDate);
        allPosts.Add(newPost);
    }
    conn.Close();
    if (conn != null)
        {
            conn.Dispose();
        }
    return allPosts;
    }


    public static Post Find(int id)
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM posts WHERE id = (@searchId);";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = id;
        cmd.Parameters.Add(searchId);
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int postId = 0;
        int postBlogId = 0;
        string postTitle = "";
        string postContent = "";
        DateTime postDate = new DateTime();
        while(rdr.Read())
        {
            postId = rdr.GetInt32(0);
            postBlogId = rdr.GetInt32(1);
            postTitle = rdr.GetString(2);
            postContent = rdr.GetString(3);
            postDate = rdr.GetDateTime(4);
        }
        Post foundPost = new Post(postTitle, postContent, postBlogId, postId);
        foundPost.SetDate(postDate);
        
        conn.Close();
        if (conn != null)
            {
                conn.Dispose();
            }
        return foundPost;
        }


        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand( "DELETE FROM posts WHERE id = @PostId;", conn);
            MySqlParameter postIdParameter = new MySqlParameter();
            postIdParameter.ParameterName = "@PostId";
            postIdParameter.Value = this.GetId();
            cmd.Parameters.Add(postIdParameter);
            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }


        public void Edit(string newTitle, string newContent)
        {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"UPDATE posts SET title = @newTitle, content = @newContent WHERE id = (@searchId);";
        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = _id;
        cmd.Parameters.Add(searchId);

        MySqlParameter title = new MySqlParameter();
        title.ParameterName = "@newTitle";
        title.Value = newTitle;
        cmd.Parameters.Add(title);

        MySqlParameter content = new MySqlParameter();
        content.ParameterName = "@newContent";
        content.Value = newContent;
        cmd.Parameters.Add(content);

        _title = newTitle;
        _content = newContent;
        conn.Close();
        if (conn != null)
            {
                conn.Dispose();
            }
        }

  }
}