namespace DistanceEducation.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }

        public int GroupId { get; set; }
        public Group group { get; set; }

        public int TeacherId { get; set; }
        public Teacher teacher { get; set;}

        public int DisciplineId { get; set; }
        public Discipline discipline { get; set; }
    }
}
