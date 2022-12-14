using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace autorisation.Models
{
    public class A_list_of_users
    {
        public int id { get; set; }
        public string Full_name { get; set; }

        public virtual Roless Role { get; set; }

        public virtual Groups Group { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Tests> Tests { get; set; }
        public virtual ICollection<Passed_Tests> Passed_Tests { get; set; }

    }
}