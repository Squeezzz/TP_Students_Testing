using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using autorisation.Models;

namespace autorisation.DAL
{
    public class DTSInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DTSContext>
    {
        protected override void Seed(DTSContext context)
        {
            var Roless = new List<Roless>
            {
            new Roless{id=1,Name="Admin"},
            new Roless{id=2,Name="Prepod"},
            new Roless{id=3,Name="Student"}
            };
            Roless.ForEach(s => context.Roless.Add(s));
            context.SaveChanges();

            var A_list_of_users = new List<A_list_of_users>
            {
            new A_list_of_users{id=1,Full_name="Очень_Важный_Чел",Role=1,Subjects="0",Group="0",Login="Admin1@gmail.com",Password="Admin1@gmail.com"},
            new A_list_of_users{id=2,Full_name="Менее_Важный_Чел",Role=2,Subjects="Маткад",Group="0",Login="Prepod1@gmail.com",Password="Prepod1@gmail.com"},
            new A_list_of_users{id=3,Full_name="Очень_Неважный_Чел",Role=3,Subjects="0",Group="ПРИ_220",Login="Student1@gmail.com",Password="Student1@gmail.com"}
            };
            A_list_of_users.ForEach(s => context.A_list_of_users.Add(s));
            context.SaveChanges();
        }
    }
}