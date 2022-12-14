using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using autorisation.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace autorisation.DAL
{
    public class DTSContext : DbContext
    {
        public DTSContext() : base("Distantion_Test_Students")
        {
        }

        public DbSet<A_list_of_users> A_list_of_users { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Passed_Tests> Passed_Tests { get; set; }
        public DbSet<Roless> Roless { get; set; }
        public DbSet<Tests> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}