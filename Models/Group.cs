namespace DistanceEducation.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }


        public ICollection<Discipline> Disciplines { get; set; }
        public ICollection<Teacher> Teachers { get; set; }

        public List<GroupTeacher> groupTeachers { get; set; }

        public List<DisciplineGroup> disciplineGroups { get; set; }
    }
}
