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
    

    public Doctor(string blogTitle, string blogDescription, int id = 0) 
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

  }
}