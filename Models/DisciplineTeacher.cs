namespace DistanceEducation.Models
{
    public class DisciplineTeacher
    {

        public int DisciplineId { get; set; }
        public Discipline discipline { get; set; }

        public int TeacherId { get; set; }
        public Teacher teacher { get; set; }


    }
}
