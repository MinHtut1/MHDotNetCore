// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

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

string query = "";
SqlCommand cmd = new SqlCommand(query, connection);



Console.ReadKey();  
