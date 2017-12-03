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
                        DepartmentId = c.Int(nullable: false),
                        JobSopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.JobSops", t => t.JobSopId)
                .Index(t => t.DepartmentId)
                .Index(t => t.JobSopId);
            
            CreateTable(
                "dbo.JobSops",
                c => new
                    {
                        JobSopId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.JobSopId);
            
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
                "dbo.ScheduleDetails",
                c => new
                    {
                        ScheduleDetailId = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Formation = c.Boolean(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleDetailId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.Jobs", t => t.JobId)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId)
                .Index(t => t.ScheduleId)
                .Index(t => t.DepartmentId)
                .Index(t => t.JobId)
                .Index(t => t.EmployeeId);
            
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
                "dbo.EmployeeJobSops",
                c => new
                    {
                        Employee_EmployeeId = c.Int(nullable: false),
                        JobSop_JobSopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeId, t.JobSop_JobSopId })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.JobSops", t => t.JobSop_JobSopId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.JobSop_JobSopId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "JobSopId", "dbo.JobSops");
            DropForeignKey("dbo.ScheduleDetails", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.ScheduleDetails", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.ScheduleDetails", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ScheduleDetails", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.EmployeeJobSops", "JobSop_JobSopId", "dbo.JobSops");
            DropForeignKey("dbo.EmployeeJobSops", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Jobs", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.EmployeeJobSops", new[] { "JobSop_JobSopId" });
            DropIndex("dbo.EmployeeJobSops", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.ScheduleDetails", new[] { "EmployeeId" });
            DropIndex("dbo.ScheduleDetails", new[] { "JobId" });
            DropIndex("dbo.ScheduleDetails", new[] { "DepartmentId" });
            DropIndex("dbo.ScheduleDetails", new[] { "ScheduleId" });
            DropIndex("dbo.Jobs", new[] { "JobSopId" });
            DropIndex("dbo.Jobs", new[] { "DepartmentId" });
            DropTable("dbo.EmployeeJobSops");
            DropTable("dbo.Schedules");
            DropTable("dbo.ScheduleDetails");
            DropTable("dbo.Employees");
            DropTable("dbo.JobSops");
            DropTable("dbo.Jobs");
            DropTable("dbo.Departments");
        }
    }
}
