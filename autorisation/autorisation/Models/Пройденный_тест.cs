using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace autorisation.Models
{
    public class Пройденный_тест
    {
        public int id { get; set; }
        public virtual Тест Тест { get; set; }

        public float Итоги { get; set; }
        public int Студент { get; set; }
        public virtual Список_пользователей Список_пользователей { get; set; }
    }
}