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
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Scheduling.Models.EF.SchedulingContext context)
        {
            //if (!System.Diagnostics.Debugger.IsAttached)
            //    System.Diagnostics.Debugger.Launch();

            var departments = new List<Department>
            {
                new Department{
                    DepartmentId = 1,
                    Title = "Yard",
                    ScheduleDetails = new List<ScheduleDetail>(),
                    Jobs = new List<Job>()},
                new Department{
                    DepartmentId = 2,
                    Title = "MSR",
                    ScheduleDetails = new List<ScheduleDetail>(),
                    Jobs = new List<Job>() },
                new Department{
                    DepartmentId = 3,
                    Title = "Finger Joint",
                    ScheduleDetails = new List<ScheduleDetail>(),
                    Jobs = new List<Job>() },
            };

            departments.ForEach(d => context.Departments.AddOrUpdate(e => e.DepartmentId, d));
            context.SaveChanges();

            var jobspos = new List<JobSop>
            {
                new JobSop
                {
                    JobSopId = 1,
                    Title = "Labor"
                },
                new JobSop
                {
                    JobSopId = 2,
                    Title = "Loader"
                },
                new JobSop
                {
                    JobSopId = 3,
                    Title = "Inside Lift"
                },
            };

            jobspos.ForEach(j => context.JobSops.AddOrUpdate(e => e.JobSopId, j));
            context.SaveChanges();

            var jobs = new List<Job>
            {
                new Job
                {
                    JobId = 1,
                    JobSopId = 1,
                    Title = "Yard / Labor",
                    DepartmentId = 1
                },
                new Job
                {
                    JobId = 2,
                    JobSopId = 1,
                    Title = "Yard / Labor",
                    DepartmentId = 1
                },
                new Job
                {
                    JobId = 3,
                    JobSopId = 2,
                    Title = "Loader #80",
                    DepartmentId = 1
                },
                new Job
                {
                    JobId = 4,
                    JobSopId = 2,
                    Title = "Loader #81",
                    DepartmentId = 1
                },
                new Job
                {
                    JobId = 5,
                    JobSopId = 2,
                    Title = "Loader #82",
                    DepartmentId = 1
                },
                new Job
                {
                    JobId = 6,
                    JobSopId = 3,
                    Title = "Inside Lift",
                    DepartmentId = 2
                },
            };

            jobs.ForEach(j => context.Jobs.AddOrUpdate(e => e.JobId, j));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = 1,
                    Firstname = "Michel",
                    Lastname = "Tremblay",
                    JobSops = new HashSet<JobSop>()
                },
                new Employee
                {
                    EmployeeId = 2,
                    Firstname = "Kevin",
                    Lastname = "Marchand",
                    JobSops = new HashSet<JobSop>()
                },
                new Employee
                {
                    EmployeeId = 3,
                    Firstname = "Christian",
                    Lastname = "Levesque",
                    JobSops = new HashSet<JobSop>()
                },
            };

            employees.ForEach(emp => context.Employees.AddOrUpdate(e => e.EmployeeId, emp));
            context.SaveChanges();

            AddOrUpdateSop(context, 1, 1);
            AddOrUpdateSop(context, 1, 2);
            AddOrUpdateSop(context, 1, 3);
            AddOrUpdateSop(context, 2, 1);
            AddOrUpdateSop(context, 2, 3);
            AddOrUpdateSop(context, 3, 1);
            context.SaveChanges();

            //var schedules = new List<Schedule>
            //{
            //    new Schedule{
            //        ScheduleId =1,
            //        Start =new DateTime(2017,12,2,8,0,0),
            //        Stop =new DateTime(2017,12,2,16,0,0),
            //        Comment ="Schedule #1",
            //        DepartmentId = 2,
            //        JobId = 6,
            //        EmployeeId=1},
            //    new Schedule{
            //        ScheduleId =2,
            //        Start =new DateTime(2017,12,2,8,0,0),
            //        Stop =new DateTime(2017,12,2,16,0,0),
            //        Comment ="Schedule #2"}
            //};

            //schedules.ForEach(s => context.Schedules.AddOrUpdate(e => e.ScheduleId, s));
            //context.SaveChanges();

        }

        void AddOrUpdateSop(SchedulingContext context, int employeeId, int sopId)
        {
            var employees = context.Employees.Include(u => u.JobSops).SingleOrDefault(s => s.EmployeeId == employeeId);
            var sop = employees.JobSops.SingleOrDefault(d => d.JobSopId == sopId);
            if (sop == null)
                employees.JobSops.Add(context.JobSops.SingleOrDefault(d => d.JobSopId == sopId));
        }

    }
}
