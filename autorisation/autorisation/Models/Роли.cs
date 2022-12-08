using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace autorisation.Models
{
    public class Роли
    {
        public int id { get; set; }
        public string Название { get; set; }

        public virtual ICollection<Список_пользователей> Список_пользователей { get; set; }
    }
}