using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace autorisation.Models
{
    public class Roless
    {
        public int id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<A_list_of_users> A_list_of_users { get; set; }
    }
}