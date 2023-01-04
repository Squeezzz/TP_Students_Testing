using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using autorisation.Models;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace autorisation.DAO
{
    public class APrrepodDAO : DAO
    {
        public bool InsertA_list_of_users(string Full_name, string Login, string Password, int id, int Role, string Subjects, SqlConnection Connection)
        {

            Connect();

            try
            {

                Debug.WriteLine("INSERT INTO [DTS] (Full_name, Login, Password, id, Role, Subjects) VALUES (N'" + Full_name + "', N'" + Login + "', '" + Password + "', N'" + id + "', '" + Role + "', '" + Subjects + "')");
                new SqlCommand("INSERT INTO [DTS] (Full_name, Login, Password, id, Role, Subjects) VALUES (N'" + Full_name + "', N'" + Login + "', '" + Password + "', N'" + id + "', '" + Role + "', '" + Subjects + "')", Connection)
                .ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);

                return false;
            }

        }

        public bool InsertA_list_of_users(string full_name, string login, string password, int id, int role, string subject, A_list_of_users t)
        {
            return InsertA_list_of_users(t.Full_name, t.Login, t.Password, t.id, t.Role, t.Subjects);
        }

        public List<A_list_of_users> GetA_list_of_users(string table = "DTS")
        {

            Connect();

            List<A_list_of_users> Distantion_Test_Students = new List<A_list_of_users>();

            using (var reader = new SqlCommand("SELECT * FROM [" + table + "]", Connection).ExecuteReader())
            {
                while (reader.Read())
                    Distantion_Test_Students.Add(new A_list_of_users() { id = (int)reader["id"], Role = (int)reader["Role"], Full_name = (string)reader["Full_name"], Login = (string)reader["Login"], Password = (string)reader["Password"], Subjects = (string)reader["Subjects"] });
            }
            return Distantion_Test_Students;
        }

        public A_list_of_users GetA_list_of_users(int id)
        {

            Connect();

            A_list_of_users ticket = new A_list_of_users();

            using (var reader = new SqlCommand("SELECT * FROM [DTS] WHERE id = " + id, Connection).ExecuteReader())
            {
                while (reader.Read())
                    ticket = (new A_list_of_users() { id = (int)reader["id"], Role = (int)reader["Role"], Full_name = (string)reader["Full_name"], Login = (string)reader["Login"], Password = (string)reader["Password"], Subjects = (string)reader["Subjects"] });

            }
            return ticket;
        }

        public bool DeleteA_list_of_users(int id)
        {

            Connect();

            try
            {
                new SqlCommand("DELETE FROM [DTS] WHERE id = " + id, Connection).ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return false;
            }

        }

        public bool EditA_list_of_users(A_list_of_users met, SqlConnection Connection)
        {

            Connect();

            try
            {
                (new SqlCommand("UPDATE [DTS] SET Full_name = '" + met.Full_name + "', Role = '" + met.Role + "', Login = '" + met.Login + "'" + ", Password = '" + met.Password + "', Subjects = '" + met.Subjects + "' WHERE id = " + met.id, Connection)).ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return false;
            }
        }

    }
}