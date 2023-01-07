using DistanceEducation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace DistanceEducation.Data
{
    public class DistanceTestDbContext : DbContext
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
        public DbSet<GroupTeacher> groupTeachers { get; set; }
        public DbSet<DisciplineGroup> disciplineGroups { get; set; }
        public DbSet<DisciplineTeacher> disciplineTeachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
            .HasMany(p => p.Teachers)
            .WithMany(p => p.Groups)
            .UsingEntity<GroupTeacher>(
                j => j
                    .HasOne(pt => pt.teacher)
                    .WithMany(t => t.groupTeachers)
                    .HasForeignKey(pt => pt.TeachersId),
                j => j
                    .HasOne(pt => pt.group)
                    .WithMany(p => p.groupTeachers)
                    .HasForeignKey(pt => pt.GroupsId)
                    );

            modelBuilder.Entity<Discipline>()
                .HasMany(p => p.Teachers)
                .WithMany(p => p.Disciplines)
                .UsingEntity<DisciplineTeacher>(
                j => j
                        .HasOne(pt => pt.teacher)
                        .WithMany(t => t.disciplineTeachers)
                        .HasForeignKey(pt => pt.TeacherId),
                j => j
                    .HasOne(pt => pt.discipline)
                    .WithMany(p => p.disciplineTeachers)
                    .HasForeignKey(pt => pt.DisciplineId)
        );

            modelBuilder.Entity<Discipline>()
                    .HasMany(p => p.Groups)
                    .WithMany(p => p.Disciplines)
                    .UsingEntity<DisciplineGroup>(
            j => j
                    .HasOne(pt => pt.group)
                    .WithMany(t => t.disciplineGroups)
                    .HasForeignKey(pt => pt.GroupsId),
            j => j
                    .HasOne(pt => pt.discipline)
                    .WithMany(p => p.disciplineGroups)
                    .HasForeignKey(pt => pt.DisciplineId)
        );
        }

    }
}
