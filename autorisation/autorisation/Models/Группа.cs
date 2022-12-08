using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace autorisation.Models
{
    public class Группа
    {
        public string Название { get; set; }
        public int Курс { get; set; }

        public virtual ICollection<Тест> Тест { get; set; }
        public virtual ICollection<Список_пользователей> Список_пользователей { get; set; }
    }
}