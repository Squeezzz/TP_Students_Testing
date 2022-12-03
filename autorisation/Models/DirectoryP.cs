using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autorisation.Models
{
    public class DirectoryP
    {
        public Prepod Id { get; set; }
        public Prepod Name { get; set; }
        public Prepod Surname { get; set; }
        public Prepod FirstName { get; set; }
        public Prepod LastName { get; set; }
        public Prepod PasswordHash { get; set; }
    }
}
