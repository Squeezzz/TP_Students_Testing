namespace DistanceEducation.Models
{
    public class Question
    {
        public int Id { get; set; }
        //текст вопроса
        public string Title { get; set; }

        //тип вопроса (либо один ответ/ либо более 1 ответа)
        public int typeQuestion { get; set; }

        //правильный ответ на вопрос
        public string RightAnswer { get; set; }

        //вторичный ключ теста
        public int TestId { get; set; }
        public Test test { get; set; }

        //Предложенные ответы на вопросы
        public string? Answer1 { get; set; }
        public string? Answer2 { get; set; }
        public string? Answer3 { get; set; }
        public string? Answer4 { get; set; }
        public string? Answer5 { get; set; }
        public string? Answer6 { get; set; }
        public string? Answer7 { get; set; }
        public string? Answer8 { get; set; }
        public string? Answer9 { get; set; }
        public string? Answer10 { get; set; }
    }
}
