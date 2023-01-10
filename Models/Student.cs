using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DistanceEducation.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

/*        [EmailAddress]
        [Remote(action: "CheckEmail", controller: "Home", ErrorMessage = "Этот Email уже занят")]*/
        public string Email { get; set; }
        public string Password { get; set; }


        //Группа студента
        public int GroupId { get; set; }
        public Group group { get; set; }

    }
}
