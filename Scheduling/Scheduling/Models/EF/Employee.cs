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
            this.Schedules = new HashSet<Schedule>();
            this.Jobs = new HashSet<Job>();
        }

        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [NotMapped]
        public string Fullname { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}