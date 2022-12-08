using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using autorisation.Models;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace autorisation.DDAO
{
    public class RecordsDAO : DAO
    {
        public bool InsertСписок_пользователей(string ФИО, string Группа, string Логин, string Пароль, int id, int Роль, SqlConnection Connection)
        {

            Connect();

            try
            {

                Debug.WriteLine("INSERT INTO [Distantion_Test_Students] (ФИО, Группа, Логин, Пароль, id, Роль) VALUES (N'" + ФИО + "', '" + Группа + "', N'" + Логин + "', '" + Пароль + "', N'" + id + "', '" + Роль + "')");
                new SqlCommand("INSERT INTO [Distantion_Test_Students] (ФИО, Группа, Логин, Пароль, id, Роль) VALUES (N'" + ФИО + "', '" + Группа + "', N'" + Логин + "', '" + Пароль + "', N'" + id + "', '" + Роль + "')", Connection)
                .ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);

                return false;
            }

        }

        public bool InsertСписок_пользователей(Список_пользователей t)
        {
            return InsertСписок_пользователей(t.ФИО, t.Группа, t.Логин, t.Пароль, t.id, t.Роль);
        }

        public List<Список_пользователей> GetMeteor(string table = "Distantion_Test_Students")
        {

            Connect();

            List<Список_пользователей> Distantion_Test_Students = new List<Список_пользователей>();

            using (var reader = new SqlCommand("SELECT * FROM [" + table + "]", Connection).ExecuteReader())
            {
                while (reader.Read())
                    Distantion_Test_Students.Add(new Список_пользователей() { id = (int)reader["id"], Роль = (int)reader["Роль"], ФИО = (string)reader["ФИО"], Группа = (string)reader["Группа"], Логин = (string)reader["Логин"], Пароль = (string)reader["Пароль"] });
            }
            return Distantion_Test_Students;
        }

        public Список_пользователей GetСписок_пользователей(int id)
        {

            Connect();

            Список_пользователей ticket = new Список_пользователей();

            using (var reader = new SqlCommand("SELECT * FROM [Distantion_Test_Students] WHERE id = " + id, Connection).ExecuteReader())
            {
                while (reader.Read())
                    ticket = (new Список_пользователей() { id = (int)reader["id"], Роль = (int)reader["Роль"], ФИО = (string)reader["ФИО"], Группа = (string)reader["Группа"], Логин = (string)reader["Логин"], Пароль = (string)reader["Пароль"] });

            }
            return ticket;
        }

        public bool DeleteСписок_пользователей(int id)
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

        public bool EditСписок_пользователей(Список_пользователей met, SqlConnection Connection)
        {

            Connect();

            try
            {
                (new SqlCommand("UPDATE [Distantion_Test_Students] SET ФИО = '" + met.ФИО + "', Группа = '" + met.Группа + "', Логин = '" + met.Логин + "'" + ", Пароль = '" + met.Пароль + "' WHERE id = " + met.id, Connection)).ExecuteNonQuery();
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