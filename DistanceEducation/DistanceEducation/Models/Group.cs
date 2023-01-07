namespace DistanceEducation.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        //Вторичный ключ предметов группы
        public int DisciplineId { get; set; }
        public Discipline discipline { get; set; }
    }
}
