using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace autorisation.Models
{
    public class Список_пользователей
    {
        public int id { get; set; }
        public string ФИО { get; set; }
        public string Должность { get; set; }

        public int Роль { get; set; }
        public virtual Роли Роли { get; set; }

        public virtual Группа Группа { get; set; }

        public string Логин { get; set; }
        public string Пароль { get; set; }

    }
}