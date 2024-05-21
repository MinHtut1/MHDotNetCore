using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//using System.Reflection.Metadata;
using System.Threading.Tasks;
using MHDotNetCore.ConsoleApp.Dtos;

namespace MHDotNetCore.ConsoleApp
{
    internal class DapperExample
    {

        pubilc void Run()
        {
            Read();
            //Edit(1);
            //Edit(11);

            //Create("title", "author", "content");
            //Update("12, title 2", "author 2", "content 2 ");
        }

        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            List<Blogdto> lst = db.Query<Blogdto>("select * from tbl_blog").ToList();

            foreach (Blogdto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("--------------------------------");
            }
        }

        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<Blogdto>("select * from tbl_blog wher blogid = @BlogId", new Blogdto { BlogId = id }).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("No Data found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            }   

        private void Creat(string title, string author, string content)
        {
            var item = new Blogdto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
            ([BlogTitle]
            ,[BlogAuthor]
            ,[BlogContent])
    VALUES
            (@BlogTitle
            ,@BlogAuthor
            ,@BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute( query, item);

            string message = result > 0 ? "Saving Successful." : "Saving Failed. ";
            Console.WriteLine(message);
        }

        private void Update (int id, string title, string author, string content) 
        {
            var item = new Blogdto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Updating Successful." : "Updating Failed. ";
            Console.WriteLine(message);
        }

        private void Delete(int id) 
        {
            var item = new Blogdto
            {
                BlogId = id,
            };

            string query = @"Delete From  [dbo].[Tbl_Blog] Where BlogID = @BlodId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Deleting Successful. " : "Deletin Failed. ";
            Console.WriteLine(message);
        }
    }
}
