using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace autorisation.Models
{
    public class Тест
    {
        public int id { get; set; }
        public string Название { get; set; }

        public int Преподаватель { get; set; }
        public virtual Роли Роли { get; set; }

        public virtual Группа Группа { get; set; }

        public DateTime Дата_начала { get; set; }
        public DateTime Дата_конца { get; set; }

        public virtual ICollection<Пройденный_тест> Пройденный_тест { get; set; }
    }
}