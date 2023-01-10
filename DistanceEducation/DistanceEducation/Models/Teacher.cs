using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DistanceEducation.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

/*        [EmailAddress]
        [Remote(action: "CheckEmail", controller: "Home", ErrorMessage = "Этот Email уже занят")]*/
        public string Email { get; set; }
        public string Password { get; set; }


        public ICollection<Discipline> Disciplines { get; set; }

        public ICollection<Group> Groups { get; set; }

        public List<GroupTeacher> groupTeachers { get; set; }
        public List<DisciplineTeacher> disciplineTeachers { get; set; }
    }
}
