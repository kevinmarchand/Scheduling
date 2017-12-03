using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scheduling.Models.EF
{
    public class Job
    {
        public Job()
        {
            this.ScheduleDetails = new HashSet<ScheduleDetail>();
            
        }

        public int JobId { get; set; }
        public string Title { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int JobSopId { get; set; }
        public JobSop JobSop { get; set; }

        public ICollection<ScheduleDetail> ScheduleDetails { get; set; }
    }
}