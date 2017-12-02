namespace Scheduling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creation : DbMigration
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
                        DeparmentId = c.Int(nullable: false),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.Department_DepartmentId);
            
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
                        DepartmentId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.JobId)
                .Index(t => t.EmployeeId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Schedules", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Schedules", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.EmployeeJobs", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.EmployeeJobs", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Jobs", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.EmployeeJobs", new[] { "Job_JobId" });
            DropIndex("dbo.EmployeeJobs", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Schedules", new[] { "EmployeeId" });
            DropIndex("dbo.Schedules", new[] { "JobId" });
            DropIndex("dbo.Schedules", new[] { "DepartmentId" });
            DropIndex("dbo.Jobs", new[] { "Department_DepartmentId" });
            DropTable("dbo.EmployeeJobs");
            DropTable("dbo.Schedules");
            DropTable("dbo.Employees");
            DropTable("dbo.Jobs");
            DropTable("dbo.Departments");
        }
    }
}
