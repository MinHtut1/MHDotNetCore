// See https://aka.ms/new-console-template for more information
using System;
using MHDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
/*
SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = ".";
stringBuilder.InitialCatalog = "MHDotNetCore.ConsoleApp";
stringBuilder.UserID = "sa";
stringBuilder.Password = "sa@123";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

connection.Open();
Console.WriteLine("Connection open.");

connection.Close(); 
Console.WriteLine("Connection close.");

string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);

foreach (DataRow dr  in dt.Rows)
{
    Console.WriteLine("Blog id => " + dr["BlogID"]);
    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
    Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
    Console.WriteLine("----------------------------");
}
*/

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title", "author", "content");
// adoDotNetExample.Update(11,"test title", "test author", "test content");
//adoDotNetExample.Delete(12);
//adoDotNetExample.Edit(12);
    
DapperExample dapperExample = new DapperExample();
dapperExample.Run();

Console.ReadLine();  
