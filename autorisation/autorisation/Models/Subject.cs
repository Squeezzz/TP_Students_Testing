using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autorisation.Models
{
    public class Subject
    {
        public string Name { get; set; }

        public virtual ICollection<Tests> Tests { get; set; }
        public virtual ICollection<A_list_of_users> Subjects { get; set; }
        public virtual ICollection<Passed_Tests> Passed_Tests { get; set; }

        public static implicit operator Subject(string v)
        {
            throw new NotImplementedException();
        }
    }
}