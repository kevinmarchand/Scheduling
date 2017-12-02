namespace Scheduling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        Stop = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ScheduleId);
            
            CreateTable(
                "dbo.JobDepartments",
                c => new
                    {
                        Job_JobId = c.Int(nullable: false),
                        Department_DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_JobId, t.Department_DepartmentId })
                .ForeignKey("dbo.Jobs", t => t.Job_JobId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId, cascadeDelete: true)
                .Index(t => t.Job_JobId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.EmployeeJobs",
                c => new
                    {
                        Employee_EmployeeId = c.Int(nullable: false),
                        Job_JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeId, t.Job_JobId })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.Job_JobId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Job_JobId);
            
            CreateTable(
                "dbo.ScheduleDepartments",
                c => new
                    {
                        Schedule_ScheduleId = c.Int(nullable: false),
                        Department_DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Schedule_ScheduleId, t.Department_DepartmentId })
                .ForeignKey("dbo.Schedules", t => t.Schedule_ScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId, cascadeDelete: true)
                .Index(t => t.Schedule_ScheduleId)
                .Index(t => t.Department_DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScheduleDepartments", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ScheduleDepartments", "Schedule_ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.EmployeeJobs", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.EmployeeJobs", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.JobDepartments", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.JobDepartments", "Job_JobId", "dbo.Jobs");
            DropIndex("dbo.ScheduleDepartments", new[] { "Department_DepartmentId" });
            DropIndex("dbo.ScheduleDepartments", new[] { "Schedule_ScheduleId" });
            DropIndex("dbo.EmployeeJobs", new[] { "Job_JobId" });
            DropIndex("dbo.EmployeeJobs", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.JobDepartments", new[] { "Department_DepartmentId" });
            DropIndex("dbo.JobDepartments", new[] { "Job_JobId" });
            DropTable("dbo.ScheduleDepartments");
            DropTable("dbo.EmployeeJobs");
            DropTable("dbo.JobDepartments");
            DropTable("dbo.Schedules");
            DropTable("dbo.Employees");
            DropTable("dbo.Jobs");
            DropTable("dbo.Departments");
        }
    }
}
