using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Scheduling.Models.EF
{
    public class SchedulingContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public SchedulingContext() : base("name=SchedulingDBConnectionString")
        {
            Database.SetInitializer<SchedulingContext>(new DropCreateDatabaseAlways<SchedulingContext>());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Schedule>()
        //        .HasOptional<Department>(s => s.Department)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);
        //}
    }
}