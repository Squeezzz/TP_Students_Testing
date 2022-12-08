using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace autorisation.DAO
{
    public class DAO
    {
        const string ConnectionString = @"Data Source=LOCALHOST\SQLEXPRESS; Initial Catalog=Distantion_Test_Students; Integrated Security=True";
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