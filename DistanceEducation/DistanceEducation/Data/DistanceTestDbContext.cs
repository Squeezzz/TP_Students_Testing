using DistanceEducation.Models;
using Microsoft.EntityFrameworkCore;

namespace DistanceEducation.Data
{
    public class DistanceTestDbContext :DbContext
    {
        public DistanceTestDbContext(DbContextOptions<DistanceTestDbContext> options) : base(options)
        { }

        public DbSet<Admin> admins { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Discipline> disciplines { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Result> results { get; set; }
        public DbSet<Test> tests { get; set; }

    }
}
