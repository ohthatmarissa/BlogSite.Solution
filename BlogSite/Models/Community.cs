using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BlogSite.Models
{
  public class Community
  {
    private int _id;
    private string _name;

    private string _description;
    

    public Community(string communityName, string communityDescription, int id = 0)
    {
      _name = communityName;
      _description = communityDescription;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }


     public string GetDescription()
    {
      return _description;
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