using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace autorisation.Models
{
    public class Group
    {
        public string Name { get; set }
        public long Course { get; set }

        public virtual ICollection<List> List { get; set }
    }
}