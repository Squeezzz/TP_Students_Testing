namespace DistanceEducation.Models
{
    public class DisciplineGroup
    {
        public int DisciplineId { get; set; }
        public Discipline discipline { get; set; }

        public int GroupsId { get; set; }
        public Group group { get; set; }



    }
}
