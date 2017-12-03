using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Scheduling.Models.EF
{
    public class Employee
    {
        public Employee()
        {
            this.ScheduleDetails = new HashSet<ScheduleDetail>();
            this.JobSops = new HashSet<JobSop>();
        }

        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [NotMapped]
        public string Fullname
        {
            get {
                return this.Firstname + " " + this.Lastname;
            }
        }

        public ICollection<ScheduleDetail> ScheduleDetails { get; set; }

        public ICollection<JobSop> JobSops { get; set; }
    }
}