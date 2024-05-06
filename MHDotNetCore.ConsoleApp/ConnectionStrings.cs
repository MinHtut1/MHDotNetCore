using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDotNetCore.ConsoleApp
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {

            DataSource = ".",
            InitialCatalog = "MHDotNetCore.ConsoleApp",
            UserID = "sa",
            Password = "sa@123",
            //TrustServiceCertificate = true

        };
    }
}
