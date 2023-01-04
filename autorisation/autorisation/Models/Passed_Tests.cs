using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace autorisation.Models
{
    public class Passed_Tests
    {
        public int id { get; set; }

        public virtual Tests Tests { get; set; }

        public virtual Subject Subjects { get; set; }

        public float Results { get; set; }
        public int Student { get; set; }
        public virtual A_list_of_users A_list_of_users { get; set; }
    }
}