using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace autorisation.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<DirectoryP> DirectoryP { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Prepod> Prepod { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Test> Test { get; set; }

    }
}
