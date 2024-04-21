using System;
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
        SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

        connection.Open();
        Console.WriteLine("Connection open.");

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

        public void Creat(string title, string author, string content)   
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
            cmd.Parameters.AddWithValue("@BlogTitle");
        cmd.Parameters.AddWithValue("@BlogTitle");
            int result = cmd.ExecuteNonQuery();
            
            connection.Close();
        }
    }
}
