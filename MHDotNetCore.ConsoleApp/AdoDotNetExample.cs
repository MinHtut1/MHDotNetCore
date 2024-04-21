﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDotNetCore.ConsoleApp
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "MHDotNetCore.ConsoleApp",
            UserID = "sa",
            Password = "sa@123";
    };

    pubilc void Read()
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

        connection.Open();
        Console.WriteLine("Connection open.");

        string query = "select * from tbl_blog";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);

        connection.Close();
        Console.WriteLine("Connection close.");

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine("Blog id => " + dr["BlogID"]);
            Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
            Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
            Console.WriteLine("Blog Content => " + dr["BlogContent"]);
            Console.WriteLine("----------------------------");
        }

    }

    public void Edit(int id)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        Console.WriteLine("Connection open.");

        string query = "select * from tbl_blog where BlogId = @BlogId";
        SqlCommand cmd = new SqlCom mand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sqlDataAdapter.Fill(dt);

        connection.Close();
        Console.WriteLine("Connection close.");

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("Blog not found.");
            return;
        }

        DataRow dr = dt.Rows[0];
        Console.WriteLine("Blog Id => " + dr["BlogId"]);
        Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
        Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
        Console.WriteLine("Blog Content => " + dr["BlogContent"]);
    }


    public void Create(string title, string author, string content)   
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogTitle", author);
            cmd.Parameters.AddWithValue("@BlogTitle", content); 
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
            
            connection.Close();
        }

    public void Update(int id, string title, string author, string content)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        cmd.Parameters.AddWithValue("@BlogTitle", author);
        cmd.Parameters.AddWithValue("@BlogTitle", content);
        int result = cmd.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        Console.WriteLine(message);
    }

    public void Delete(int id)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        string query = @"delete from Tbl_Blog where BlogId = @BlogId";
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@BlogId", id);
        int result = command.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Delete Successfully" : "Delete Fail";
        Console.WriteLine(message);
    }

   }

}
