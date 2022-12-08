using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using autorisation.Models;
using System.Diagnostics;

namespace autorisation.DAO 
{
    public class RecordsDAO : DAO
    {
        public bool InsertMeteor(string Name, string Zone, string Zonesky, int Time)
        {

            Connect();

            try
            {

                Debug.WriteLine("INSERT INTO [Nabludenia] (Name, Zone, Zonesky, Time) VALUES (N'" + Name + "', '" + Zone + "', N'" + Zonesky + "', '" + Time + "')");
                new SqlCommand("INSERT INTO [Nabludenia] (Name, Zone, Zonesky, Time) VALUES (N'" + Name + "', '" + Zone + "', N'" + Zonesky + "', '" + Time + "')", Connection)
                .ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);

                return false;
            }

        }

        public bool InsertMeteor(Meteor t)
        {
            return InsertMeteor(t.Name, t.Zone, t.Zonesky, t.Time);
        }

        public List<Meteor> GetMeteor(string table = "Nabludenia")
        {

            Connect();

            List<Meteor> Nabludenia = new List<Meteor>();

            using (var reader = (new SqlCommand("SELECT * FROM [" + table + "]", Connection)).ExecuteReader())
            {
                while (reader.Read())
                    Nabludenia.Add(new Meteor() { Id = (int)reader["Id"], Name = (string)reader["Name"], Zone = (string)reader["Zone"], Zonesky = (string)reader["Zonesky"], Time = (int)reader["Time"] });
            }
            return Nabludenia;
        }

        public Meteor GetMeteor(int Id)
        {

            Connect();

            Meteor ticket = new Meteor();

            using (var reader = (new SqlCommand("SELECT * FROM [Nabludenia] WHERE Id = " + Id, Connection)).ExecuteReader())
            {
                while (reader.Read())
                    ticket = (new Meteor() { Id = (int)reader["Id"], Name = (string)reader["Name"], Zone = (string)reader["Zone"], Zonesky = (string)reader["Zonesky"], Time = (int)reader["Time"] });

            }
            return ticket;
        }

        public bool DeleteMeteor(int Id)
        {

            Connect();

            try
            {
                (new SqlCommand("DELETE FROM [Nabludenia] WHERE Id = " + Id, Connection)).ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return false;
            }

        }

        public bool EditMeteor(Meteor met)
        {

            Connect();

            try
            {
                (new SqlCommand("UPDATE [Nabludenia] SET Name = '" + met.Name + "', Zone = '" + met.Zone + "', Zonesky = '" + met.Zonesky + "'" + ", Time = '" + met.Time + "' WHERE Id = " + met.Id, Connection)).ExecuteNonQuery();
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