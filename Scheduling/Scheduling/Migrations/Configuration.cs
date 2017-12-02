namespace Scheduling.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;
    using Scheduling.Models.EF;

    internal sealed class Configuration : DbMigrationsConfiguration<Scheduling.Models.EF.SchedulingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Scheduling.Models.EF.SchedulingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var departments = new List<Department>
            {
                new Department{DepartmentId = 1,Title = "Yard",Jobs = new List<Job>(),Schedules = new List<Schedule>() },
                new Department{DepartmentId = 2,Title = "MSR",Jobs = new List<Job>(),Schedules = new List<Schedule>() },
                new Department{DepartmentId = 3,Title = "Finger Joint",Jobs = new List<Job>(),Schedules = new List<Schedule>() },
            };

            departments.ForEach(d => context.Departments.AddOrUpdate(e => e.DepartmentId, d));
            context.SaveChanges();

            var schedules = new List<Schedule>
            {
                new Schedule{
                    ScheduleId =1,
                    Start =new DateTime(2017,12,2,8,0,0),
                    Stop =new DateTime(2017,12,2,16,0,0),
                    Comment ="Schedule #1",
                    Departments = new List<Department>()},
                new Schedule{
                    ScheduleId =2,
                    Start =new DateTime(2017,12,2,8,0,0),
                    Stop =new DateTime(2017,12,2,16,0,0),
                    Comment ="Schedule #2",
                    Departments = new List<Department>()}
            };

            schedules.ForEach(s => context.Schedules.AddOrUpdate(e => e.ScheduleId, s));
            context.SaveChanges();

            AddOrUpdateDepartment(context, 1, 1);
            AddOrUpdateDepartment(context, 1, 2);
            AddOrUpdateDepartment(context, 1, 3);
            AddOrUpdateDepartment(context, 2, 3);
            context.SaveChanges();

        }

        void AddOrUpdateDepartment(SchedulingContext context, int scheduleId, int departmentId)
        {
            var schedule = context.Schedules.SingleOrDefault(s => s.ScheduleId == scheduleId);
            var department = schedule.Departments.SingleOrDefault(d => d.DepartmentId == departmentId);
            if (department == null)
                schedule.Departments.Add(context.Departments.SingleOrDefault(d => d.DepartmentId == departmentId));
        }
    }
}
