using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace autorisation.Models
{
    public class Tests
    {
        public int id { get; set; }
        public string Name { get; set; }

        public int Teacher { get; set; }

        public virtual Groups Group { get; set; }

        public virtual Subject Subjects { get; set; }

        public DateTime The_date_of_the_beginning { get; set; }
        public DateTime End_date { get; set; }

        public virtual ICollection<Passed_Tests> Passed_Tests { get; set; }
    }
}