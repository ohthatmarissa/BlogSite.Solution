using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace BlogSite.Models
{
    public class SessionBlog
    {
        private int _id;
        private int _userId;
    
        public SessionBlog(int userId, int id = 0)
        {
            _userId = userId;
            _id = id;
        }

        public static int GetId()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd= conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT blog_id FROM session_blogs;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int currentId = 0;
            while(rdr.Read())
            {
                currentId = rdr.GetInt32(0);
            }
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return currentId;
        }

        public static void Logout()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM session_blogs;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
        }
    }
}