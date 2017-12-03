using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling.Models.EF
{
    public class ScheduleDetail
    {
        public ScheduleDetail()
        {

        }

        public int ScheduleDetailId { get; set; }
        public string Comment { get; set; }
        public bool Formation { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}