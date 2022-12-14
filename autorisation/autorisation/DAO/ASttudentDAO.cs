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
    public class ASttudentDAO : DAO
    {

        public bool InsertA_list_of_users(string Full_name, string Group, string Login, string Password, int id, int Role, SqlConnection Connection)
        {

            Connect();

            try
            {

                Debug.WriteLine("INSERT INTO [Distantion_Test_Students] (Full_name, Group, Login, Password, id, Role) VALUES (N'" + Full_name + "', '" + Group + "', N'" + Login + "', '" + Password + "', N'" + id + "', '" + Role + "')");
                new SqlCommand("INSERT INTO [Distantion_Test_Students] (Full_name, Group, Login, Password, id, Role) VALUES (N'" + Full_name + "', '" + Group + "', N'" + Login + "', '" + Password + "', N'" + id + "', '" + Role + "')", Connection)
                .ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);

                return false;
            }

        }

        public bool InsertA_list_of_users(string full_name, Groups group, string login, string password, int id, int role, A_list_of_users t)
        {
            return InsertA_list_of_users(t.Full_name, t.Group, t.Login, t.Password, t.id, t.Role);
        }

        public List<A_list_of_users> GetA_list_of_users(string table = "Distantion_Test_Students")
        {

            Connect();

            List<A_list_of_users> Distantion_Test_Students = new List<A_list_of_users>();

            using (var reader = new SqlCommand("SELECT * FROM [" + table + "]", Connection).ExecuteReader())
            {
                while (reader.Read())
                    Distantion_Test_Students.Add(new A_list_of_users() { id = (int)reader["id"], Role = (int)reader["Role"], Full_name = (string)reader["Full_name"], Group = (string)reader["Group"], Login = (string)reader["Login"], Password = (string)reader["Password"] });
            }
            return Distantion_Test_Students;
        }

        public A_list_of_users GetA_list_of_users(int id)
        {

            Connect();

            A_list_of_users ticket = new A_list_of_users();

            using (var reader = new SqlCommand("SELECT * FROM [Distantion_Test_Students] WHERE id = " + id, Connection).ExecuteReader())
            {
                while (reader.Read())
                    ticket = (new A_list_of_users() { id = (int)reader["id"], Role = (int)reader["Role"], Full_name = (string)reader["Full_name"], Group = (string)reader["Group"], Login = (string)reader["Login"], Password = (string)reader["Password"] });

            }
            return ticket;
        }

        public bool DeleteA_list_of_users(int id)
        {

            Connect();

            try
            {
                new SqlCommand("DELETE FROM [Distantion_Test_Students] WHERE id = " + id, Connection).ExecuteNonQuery();

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
                (new SqlCommand("UPDATE [Distantion_Test_Students] SET Full_name = '" + met.Full_name + "', Role = '" + met.Role + "', Group = '" + met.Group + "', Login = '" + met.Login + "'" + ", Password = '" + met.Password + "' WHERE id = " + met.id, Connection)).ExecuteNonQuery();
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