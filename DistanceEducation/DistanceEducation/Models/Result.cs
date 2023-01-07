namespace DistanceEducation.Models
{
    public class Result
    {
        public int Id { get; set; }
        public double Itog { get; set; }

        //Вторичный ключ теста
        public int TestId { get; set; }
        public Test test { get; set; }

        //Вторичный ключ студента
        public int StudentId { get; set; }
        public Student student { get; set; }
    }
}
