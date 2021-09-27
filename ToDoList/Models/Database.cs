using MySql.Data.MySqlClient;
using System;
using ToDoList;

namespace ToDoList.Models
{
    
}public class DB
{
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
}