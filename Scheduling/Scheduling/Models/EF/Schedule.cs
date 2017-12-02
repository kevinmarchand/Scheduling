using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling.Models.EF
{
    public class Schedule
    {
        public Schedule()
        {
        }

        public int ScheduleId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public string Comment { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}