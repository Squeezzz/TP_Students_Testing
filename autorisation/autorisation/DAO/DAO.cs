using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace autorisation.DAO
{
    public class DAO
    {
        const string ConnectionString = @"Data Source=LOCALHOST\SQLEXPRESS; Initial Catalog=DTS; Integrated Security=True";
        public SqlConnection Connection { get; set; }
        public void Connect()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }
        public void Disconnect()
        {
            Connection.Close();
        }

    }
}