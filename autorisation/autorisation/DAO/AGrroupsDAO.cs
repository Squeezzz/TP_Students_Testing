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
    public class AGrroupsDAO : DAO
    {
        public bool InsertGroups(string Name, int Well, SqlConnection Connection)
        {

            Connect();

            try
            {

                Debug.WriteLine("INSERT INTO [Distantion_Test_Students] (Name, Well) VALUES (N'" + Name + "', '" + Well + "')");
                new SqlCommand("INSERT INTO [Distantion_Test_Students] (Name, Well) VALUES (N'" + Name + "', '" + Well + "')", Connection)
                .ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);

                return false;
            }

        }

        public bool InsertGroups(string Name, int Well, Groups t)
        {
            return InsertGroups(t.Name, t.Well);
        }

        public List<Groups> GetGroups(string table = "Distantion_Test_Students")
        {

            Connect();

            List<Groups> Distantion_Test_Students = new List<Groups>();

            using (var reader = new SqlCommand("SELECT * FROM [" + table + "]", Connection).ExecuteReader())
            {
                while (reader.Read())
                    Distantion_Test_Students.Add(new Groups() { Well = (int)reader["Well"], Name = (string)reader["Name"] });
            }
            return Distantion_Test_Students;
        }

        public Groups GetGroups(int Name)
        {

            Connect();

            Groups ticket = new Groups();

            using (var reader = new SqlCommand("SELECT * FROM [Distantion_Test_Students] WHERE Name = " + Name, Connection).ExecuteReader())
            {
                while (reader.Read())
                    ticket = (new Groups() { Well = (int)reader["Well"], Name = (string)reader["Name"] });

            }
            return ticket;
        }

        public bool DeleteGroups(int Name)
        {

            Connect();

            try
            {
                new SqlCommand("DELETE FROM [Distantion_Test_Students] WHERE Name = " + Name, Connection).ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return false;
            }

        }

        public bool EditGroups(Groups met, SqlConnection Connection)
        {

            Connect();

            try
            {
                (new SqlCommand("UPDATE [Distantion_Test_Students] SET Well = '" + met.Well + "' WHERE Name = " + met.Name, Connection)).ExecuteNonQuery();
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