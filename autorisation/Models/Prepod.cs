using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autorisation.Models
{
    public class Prepod
    {
        public long Id { get; set; }
        public UserRole Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
    }
}
