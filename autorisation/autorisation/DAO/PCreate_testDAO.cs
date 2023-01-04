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
    public class PCreate_testDAO : DAO
    {
        public bool InsertGroups(string Name, int Well, SqlConnection Connection)
        {

            Connect();

            try
            {

                Debug.WriteLine("INSERT INTO [DTS] (Name, Well) VALUES (N'" + Name + "', '" + Well + "')");
                new SqlCommand("INSERT INTO [DTS] (Name, Well) VALUES (N'" + Name + "', '" + Well + "')", Connection)
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

        public List<Groups> GetGroups(string table = "DTS")
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

            using (var reader = new SqlCommand("SELECT * FROM [DTS] WHERE Name = " + Name, Connection).ExecuteReader())
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
                new SqlCommand("DELETE FROM [DTS] WHERE Name = " + Name, Connection).ExecuteNonQuery();

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
                (new SqlCommand("UPDATE [DTS] SET Well = '" + met.Well + "' WHERE Name = " + met.Name, Connection)).ExecuteNonQuery();
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