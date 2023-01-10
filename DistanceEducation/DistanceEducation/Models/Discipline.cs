namespace DistanceEducation.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string DisciplineName { get; set; }

        public ICollection<Teacher> Teachers { get; set; }

        public ICollection<Group> Groups { get; set; }

        public List<DisciplineGroup> disciplineGroups { get; set; }

        public List<DisciplineTeacher> disciplineTeachers { get; set; }
    }
}
